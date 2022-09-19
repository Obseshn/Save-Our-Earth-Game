using System.Collections;
using System;
using UnityEngine;
using YG;

public class Earth : MonoBehaviour
{
    public Action<int> OnEarthTakenDamage;
    public Action OnCatastropheStartedOrFinished;

    [SerializeField] private Material catastropheMaterial;
    [SerializeField] private CatastropheCounter catastropheCounter;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int startEarthHealth = 5;
    [SerializeField] private AudioClip catastropheClip;
    [SerializeField] private GameObject gameoverMenu;

    private HealthSystem healthSystem;
    private CosmicObjectsRotator cosmicObjectsRotator;
    
    private bool isOnCatastrophe = false;
    private MeshRenderer earthMeshRenderer;
    private Material[] defaultMaterials;

    private readonly int catastropheDamage  = 3;
    
    
    private void Start()
    {
        cosmicObjectsRotator = GetComponent<CosmicObjectsRotator>();

        healthSystem = new HealthSystem(startEarthHealth);
        healthSystem.OnObjectDied += DestroyPlanet;
        healthSystem.OnObjectTakenDamage += OnTakeDamageBehaviour;

        healthBar.SetMaxHealth(healthSystem.maxHealth);

        catastropheCounter.OnCatastropheReady += MakeCatastrophe;

        earthMeshRenderer = GetComponentInChildren<MeshRenderer>();
        defaultMaterials = earthMeshRenderer.materials;
    }

    private void Update()
    {
        cosmicObjectsRotator.RotateObjectYAxis();
    }
    protected virtual void OnTakeDamageBehaviour()
    {
        Debug.Log(transform.name + " taken damage!");
        OnEarthTakenDamage?.Invoke(healthSystem.currentHealth);
        healthBar.SetHealth(healthSystem.currentHealth);
    }

    private void CheckMaxScore()
    {
        int currentMaxScore = YandexGame.savesData.playerMaxScore;
        if (currentMaxScore < FindObjectOfType<UIController>().GetScore())
        {
            YandexGame.savesData.playerMaxScore = FindObjectOfType<UIController>().GetScore();
            YandexGame.NewLeaderboardScores("Best Players", FindObjectOfType<UIController>().GetScore());
            YandexGame.SaveProgress();
        }
    }


    protected virtual void DestroyPlanet()
    {
        Time.timeScale = 0;
        gameoverMenu.SetActive(true);

        CheckMaxScore();

        /*Destroy(gameObject);*/
    }

    public void ResetHP()
    {
        isOnCatastrophe = false;
        earthMeshRenderer.materials = defaultMaterials;

        healthSystem.currentHealth = healthSystem.maxHealth;
        healthBar.SetHealth(healthSystem.maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Attacker>())
        {
            healthSystem.TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (isOnCatastrophe)
        {
            int randomTrueOrFalse = UnityEngine.Random.Range(0, 2);
            if (randomTrueOrFalse == 1)
            {
                isOnCatastrophe = false;
                earthMeshRenderer.materials = defaultMaterials;
                Debug.Log("Catastrophe has been stopped!");
                OnCatastropheStartedOrFinished?.Invoke();
            }
        }
    }
    
    private void MakeCatastrophe()
    {
        if (!isOnCatastrophe!)
        {
            SoundManager.Instance.PlaySound(catastropheClip);
            OnCatastropheStartedOrFinished?.Invoke();
            isOnCatastrophe = true;

            Color randomColor = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f),/*blue: */  0, UnityEngine.Random.Range(0, 1f)); // 3rd is zero because it's default color of earth water
            catastropheMaterial.color = randomColor;

            earthMeshRenderer.material = catastropheMaterial;
            StartCoroutine(CatastropheDelay(5));
        }
    }

    IEnumerator CatastropheDelay(float delayTimeInSec)
    {
        Debug.Log("Catastrophe started!");
        yield return new WaitForSeconds(delayTimeInSec);
        if (isOnCatastrophe)
        {
            healthSystem.TakeDamage(catastropheDamage);
        }
    }
    private void OnDisable()
    {
        healthSystem.OnObjectDied -= DestroyPlanet;
        healthSystem.OnObjectTakenDamage -= OnTakeDamageBehaviour;
        catastropheCounter.OnCatastropheReady -= MakeCatastrophe;
    }

    public int GetEarthStartHealth()
    {
        return startEarthHealth;
    }
}

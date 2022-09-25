using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;
using YG;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private static Action<int> OnAddScore;
    private static int scoreCounter;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Text earthHealthText;

    [SerializeField] private Image catastropheMenu;
    [SerializeField] private GameObject gameOverMenu;
    private Earth earth;


    

    private void Start()
    {
        Attacker.OnAttackerDied += AddScore;
        
        OnAddScore += ChangeScoreText;

        YandexGame.CloseVideoEvent += Reward;

        earth = FindObjectOfType<Earth>();
        earth.OnCatastropheStartedOrFinished += ShowOrHideCatastropheMenu;
        earth.OnEarthTakenDamage += ChangeEarthHealthText;
        earthHealthText.text = earth.GetEarthStartHealth().ToString();
        

        scoreCounter = 0;
    }

    public void Reward(int rewardID)
    {
        if (rewardID == 1)
        {
            Earth earth = FindObjectOfType<Earth>();
            earth.ResetHP();
            gameOverMenu.SetActive(false);
            Collider[] nearestEnemies = Physics.OverlapSphere(earth.transform.position, 15f, enemyLayer);
            foreach (var enemy in nearestEnemies)
            {
                enemy.GetComponent<Attacker>().DestroyAttacker();
            }
        }
        if (rewardID == 2)
        {
            Attacker[] enemies = FindObjectsOfType<Attacker>();
            foreach (var enemy in enemies)
            {
                enemy.DestroyAttacker();
            }
        }
    }
    public static void AddScore()
    {
        scoreCounter += 1;
        Debug.Log("Add score exist!");
        OnAddScore?.Invoke(scoreCounter);
    }

    private void ChangeScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
    
    public void ChangeEarthHealthText(int newHealth)
    {
        earthHealthText.text = newHealth.ToString();
    }

    private void OnDisable()
    {
        Attacker.OnAttackerDied -= AddScore;

        OnAddScore -= ChangeScoreText;

        earth.OnEarthTakenDamage -= ChangeEarthHealthText;
        earth.OnCatastropheStartedOrFinished -= ShowOrHideCatastropheMenu;
    }

    private void ShowOrHideCatastropheMenu()
    {
        if (catastropheMenu.isActiveAndEnabled)
        {
            catastropheMenu.gameObject.SetActive(false);
        }
        else
        {
            catastropheMenu.gameObject.SetActive(true);
        }
    }

    public void RestartLevel()
    {
/*        ColorPickerTriangle colorPicker = FindObjectOfType<ColorPickerTriangle>();
        Color bgColor = colorPicker.TheColor;*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
/*        colorPicker.SetNewColor(bgColor);*/
    }

    public void GoToMainMenu()
    {
        if (scoreCounter > YandexGame.savesData.playerMaxScore)
        {
            YandexGame.savesData.playerMaxScore = scoreCounter;
            YandexGame.SaveProgress();
        }

        SceneManager.LoadScene("MainMenu");

    }

    public int GetScore()
    {
        return scoreCounter;
    }
}

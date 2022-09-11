using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private static Action<int> OnAddScore;
    private static int scoreCounter;

    [SerializeField] private Text earthHealthText;

    [SerializeField] private Image catastropheMenu;

    private void Start()
    {
        Attacker.OnAttackerDied += AddScore;

        OnAddScore += ChangeScoreText;

        Earth earth = FindObjectOfType<Earth>();
        earth.OnCatastropheStartedOrFinished += ShowOrHideCatastropheMenu;
        earth.OnEarthTakenDamage += ChangeEarthHealthText;
        earthHealthText.text = earth.GetEarthStartHealth().ToString();
        

        scoreCounter = 0;
        scoreText.text = "Удачной игры!";
    }

    public static void AddScore()
    {
        scoreCounter += 1;
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
        OnAddScore -= ChangeScoreText;
        Earth earth = FindObjectOfType<Earth>();
        earth.OnEarthTakenDamage -= ChangeEarthHealthText;
        earth.OnCatastropheStartedOrFinished -= ShowOrHideCatastropheMenu;
        earth.OnEarthTakenDamage -= ChangeEarthHealthText;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

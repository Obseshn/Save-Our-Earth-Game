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
    private Earth earth;

    private void Start()
    {
        Attacker.OnAttackerDied += AddScore;

        OnAddScore += ChangeScoreText;

        earth = FindObjectOfType<Earth>();
        earth.OnCatastropheStartedOrFinished += ShowOrHideCatastropheMenu;
        earth.OnEarthTakenDamage += ChangeEarthHealthText;
        earthHealthText.text = earth.GetEarthStartHealth().ToString();
        

        scoreCounter = 0;
        scoreText.text = "Удачной игры!";
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

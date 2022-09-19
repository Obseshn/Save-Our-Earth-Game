using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MainMenuCanvas : MonoBehaviour
{

    private GameObject colorPicker;
    [SerializeField] private Text playerBestScoreText;
    [SerializeField] private LeaderboardYG leaderBoard;

    private void OnEnable()
    {
        YandexGame.CloseVideoEvent += Reward;

        YandexGame.GetDataEvent += OnGotData;
        colorPicker = ColorPickerTriangle.Instance.gameObject;
        if (YandexGame.savesData.playerMaxScore > 0)
        {
            leaderBoard.NewScore(YandexGame.savesData.playerMaxScore);
        }
        leaderBoard.UpdateLB();
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= OnGotData;
    }
    private void Start()
    {
        playerBestScoreText.text = YandexGame.savesData.playerMaxScore.ToString();
    }

    private void OnGotData()
    {
        playerBestScoreText.text = YandexGame.savesData.playerMaxScore.ToString();
    }

    public void Reward(int rewardIndex)
    {
        if (rewardIndex == 0)
        {
            Debug.Log("Reward 0");
            colorPicker.SetActive(true);
        }
    }

    public void StartGame()
    {
        colorPicker.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
}

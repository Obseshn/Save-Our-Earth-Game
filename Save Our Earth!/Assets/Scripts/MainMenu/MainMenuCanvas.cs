using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MainMenuCanvas : MonoBehaviour
{

    private GameObject colorPicker;
    [SerializeField] private Text playerBestScoreText;
    [SerializeField] private LeaderboardYG leaderBoard;
    [SerializeField] private GameObject[] AuthDisableGameobjects;
    [SerializeField] private GameObject[] AuthEnableGameobjects;

    private void OnEnable()
    {
        YandexGame.CloseVideoEvent += Reward;

        YandexGame.GetDataEvent += OnGotData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= OnGotData;
    }
    private void Start()
    {
        playerBestScoreText.text = YandexGame.savesData.playerMaxScore.ToString();

        if (!YandexGame.auth)
        {
            foreach (var obj in AuthDisableGameobjects)
            {
                obj.SetActive(false);
            }
           
        }
        else
        {
            foreach (var obj in AuthEnableGameobjects)
            {
                obj.SetActive(false);
            }
        }
        colorPicker = ColorPickerTriangle.Instance.gameObject;
        colorPicker.SetActive(false);
    }

    public void UpdateLB()
    {
        leaderBoard.UpdateLB();
    }
    public void PlayButtonSound()
    {
        SoundManager.Instance.PlayButtonSound();
    }

    private void OnGotData()
    {
        playerBestScoreText.text = YandexGame.savesData.playerMaxScore.ToString();
        if (YandexGame.savesData.playerMaxScore > 0)
        {
            leaderBoard.NewScore(YandexGame.savesData.playerMaxScore);
        }
        leaderBoard.UpdateLB();
    }

    public void Reward(int rewardIndex)
    {
        if (rewardIndex == 0)
        {
            Debug.Log("Reward 0");
            colorPicker.SetActive(true);
        }
    }

    public void ActivateColorPicker()
    {
        YandexGame.RewVideoShow(0);
    }
    public void StartGame()
    {
        colorPicker.SetActive(false);
        YandexGame.FullscreenShow();
        SceneManager.LoadScene("GamePlay");
    }
}

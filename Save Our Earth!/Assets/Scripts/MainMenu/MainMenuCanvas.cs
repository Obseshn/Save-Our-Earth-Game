using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}

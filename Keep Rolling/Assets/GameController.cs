using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        Time.timeScale = 0f;
    }

    public void OnButtonClick()
    {
        HideCanvasAndStartGame();
    }

    private void HideCanvasAndStartGame()
    {
        Time.timeScale = 1f;
        canvas.SetActive(false);
    }

    public void RestartLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void NextLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        var nextScene = currentScene + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            // TODO show game over message
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private TextMeshProUGUI subMessage;
    private static bool isGameWon = false;
    private static GameObject canvas;

    void Start()
    {
        subMessage = GameObject.FindWithTag("SubMessage").GetComponent<TextMeshProUGUI>();
        canvas = GameObject.FindWithTag("Canvas");
        InitScene();
    }

    private void InitScene()
    {
        var currentScene = GetCurrentSceneIndex();
        subMessage.text = "Level " + (currentScene + 1);
        if (currentScene == 0)
        {
            isGameWon = false;
        }
        Time.timeScale = 0f;
    }

    public static void OnButtonClick()
    {
        if (isGameWon)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            HideCanvasAndStartScene();
        }
    }

    private static void HideCanvasAndStartScene()
    {
        Time.timeScale = 1f;
        SetCanvasVisibility(isVisible: false);
    }

    public void RestartLevel()
    {
        var currentScene = GetCurrentSceneIndex();
        SceneManager.LoadScene(currentScene);
    }

    public void NextLevel()
    {
        var currentScene = GetCurrentSceneIndex();
        var nextScene = currentScene + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Time.timeScale = 0f;
            subMessage.text = "You win!";
            isGameWon = true;
            SetCanvasVisibility(isVisible: true);
        }
    }

    private static void SetCanvasVisibility(bool isVisible)
    {
        canvas.SetActive(isVisible);
    }

    private static int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}

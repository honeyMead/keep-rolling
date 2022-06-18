using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int Tries = 0;
    private static float TimeSinceGameRunStart = 0f;

    private TextMeshProUGUI subMessage;
    private TextMeshProUGUI buttonMessage;
    private static bool isGameWon = false;
    private static GameObject canvas;

    void Start()
    {
        subMessage = GameObject.FindWithTag("SubMessage").GetComponent<TextMeshProUGUI>();
        buttonMessage = GameObject.FindWithTag("ButtonMessage").GetComponent<TextMeshProUGUI>();
        canvas = GameObject.FindWithTag("Canvas");
        InitScene();
    }

    private void InitScene()
    {
        var currentScene = GetCurrentSceneIndex();
        subMessage.text = "Level " + (currentScene + 1);
        buttonMessage.text = "Start";

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
            Tries = 0;
            TimeSinceGameRunStart += Time.time;
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
            subMessage.text = GetWinningText();
            buttonMessage.text = "Replay";
            isGameWon = true;
            SetCanvasVisibility(isVisible: true);
        }
    }

    private static string GetWinningText()
    {
        var timePassed = Time.time - TimeSinceGameRunStart; // TODO format
        var minutes = Mathf.FloorToInt(timePassed / 60);
        var seconds = Mathf.FloorToInt(timePassed % 60);
        var formattedTime = $"{minutes:00}:{seconds:00}";

        return "You win!" + "\n"
            + $"Tries: {Tries + 1}" + "\n"
            + $"Time: {formattedTime}";
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

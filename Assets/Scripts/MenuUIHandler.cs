using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputText;
    public TMP_Text HighScore;

    private void Start()
    {
        HighScore.text = $"BEST SCORE: {MenuManager.Instance.recordName}: {MenuManager.Instance.recordScore}";
    }

    public void StartNew()
    {
        MenuManager.Instance.username = inputText.text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}

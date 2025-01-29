using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScoreText;
    public TMP_InputField nameInput;

    private void Start()
    {
        if (DataManager.Instance.gameData.highScore == 0)
        {
            highScoreText.text = "Best Score : 0";
        } else
        {
            highScoreText.text = "Best Score: " + DataManager.Instance.gameData.highScoreName + " : " + DataManager.Instance.gameData.highScore;
        }
    }

    public void StartGame()
   {
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            DataManager.Instance.playerName = nameInput.text;
            SceneManager.LoadScene("main");
        }else
        {
            Debug.Log("Input your name first");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Berhenti di Unity Editor
#else
            Application.Quit(); // Keluar saat di-build
#endif
    }

    public void ResetHighScore()
    {
        DataManager.Instance.ResetScore();
        highScoreText.text = "Best Score: 0";
    }
}

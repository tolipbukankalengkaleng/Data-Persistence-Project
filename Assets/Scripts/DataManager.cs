using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public string highScoreName;
        public int highScore;
    }

    public static DataManager Instance;

    public string playerName;

    public GameData gameData = new GameData();

    private string saveFilePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        saveFilePath = Application.persistentDataPath + "/saveData.json";
        LoadHighScore();
    }

    public void SaveHighScore(int score)
    {
        if (score > gameData.highScore)
        {
            gameData.highScore = score;
            gameData.highScoreName = playerName;

            string json = JsonUtility.ToJson(gameData, true);
            File.WriteAllText(saveFilePath, json);
        }
    }

    private void LoadHighScore()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            gameData.highScore = 0;
            gameData.highScoreName = "No Name";
        }
    }

    public void ResetScore()
    {
        // Reset high score dan nama pemain
        gameData.highScore = 0;
        gameData.highScoreName = "No Name";

        // Menyimpan perubahan ke file JSON
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(saveFilePath, json);
    }
}

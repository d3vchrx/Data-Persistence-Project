using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public string username;

    public string recordName;
    public int recordScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        username = "";
        DontDestroyOnLoad(gameObject);

        loadRecord();
    }

    [System.Serializable]
    public class HighScore
    {
        public string name;
        public int score;
    }

    public void saveRecord(int score)
    {
        HighScore highScore = new HighScore();
        highScore.name = this.username;
        highScore.score = score;

        string json = JsonUtility.ToJson(highScore);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            HighScore data = JsonUtility.FromJson<HighScore>(json);

            recordName = data.name;
            recordScore = data.score;
        }
        else
        {
            recordName = username;
            recordScore = 0;
        }
    }
}

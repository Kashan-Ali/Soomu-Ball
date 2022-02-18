using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

<<<<<<< Updated upstream
    //  Fieldes
=======
    //  Fields
    [Header("For Current Player")]
>>>>>>> Stashed changes
    public string playername;

    //  for load best player states.
    public string bestName;
    public int highScore;
    public int maxWave;

    //  Properties
    public string BestName
    {
        get { return bestName; }
        set { bestName = value; }
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public string bestName;
        public int highScore;
        public int maxWave;
    }

    public void SaveHighScore(string bestName, int bestScore, int maxWave)
    {
        SaveData data = new SaveData();
        data.bestName = bestName;
        data.highScore = bestScore;
        data.maxWave = maxWave;

        string createData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", createData);

        Debug.Log(Application.persistentDataPath + "/savefile.json");
        Debug.Log(createData);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string readData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(readData);

            bestName = data.bestName;
            highScore = data.highScore;
            maxWave = data.maxWave;
        }
    }

}

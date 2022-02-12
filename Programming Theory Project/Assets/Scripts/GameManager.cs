using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //  Fieldes
    public string playername;
    private string bestName;
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
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //  Fields
    public string playername;
    private string bestName;
    public int highScore;
    public int maxWave;
    // end Fields

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

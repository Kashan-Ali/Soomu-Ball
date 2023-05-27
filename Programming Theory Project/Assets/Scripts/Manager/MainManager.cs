using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    [Header("Fields for Current Player.")]
    [SerializeField] private TMP_Text _currentName;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _currentWave;

    [Header("Best Score Elements in HUD.")]
    [SerializeField] private TMP_Text _bestName;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private TMP_Text _bestWave;

    [Header("GameOver Player States.")]
    [SerializeField] private TMP_Text _highScoreLogo;
    [SerializeField] private TMP_Text _finalName;
    [SerializeField] private TMP_Text _finalScore;
    [SerializeField] private TMP_Text _finalWave;
    
    private SpawnManager _SpawnManager;

    private void OnEnable()
    {
        _SpawnManager = FindObjectOfType<SpawnManager>();

        CurrentPlayerName();

        GameManager.Instance.LoadHighScore();
        BestPlayerName();
        BestPlayerStates();
    }

    private void Update()
    {
        CurrentPlayerStates();
    }

    private void CurrentPlayerName()
    {
        string currentNameOut = _currentName.text.ToUpper() + GameManager.Instance.playername.ToUpper();
        _currentName.text = currentNameOut;
    }

    private void BestPlayerName()
    {
        string bestNameOut = _bestName.text.ToUpper() + GameManager.Instance.bestName.ToUpper();
        _bestName.text = bestNameOut;
    }

    private void CurrentPlayerStates()
    {
        _currentScore.text = "SCORE: " + _SpawnManager.score.ToString();
        _currentWave.text = "WAVE: " + _SpawnManager.wave.ToString();
    }

    private void BestPlayerStates()
    {
        _bestScore.text = "HIGH SCORE: " + GameManager.Instance.highScore.ToString();
        _bestWave.text = "MAX WAVE: " + GameManager.Instance.maxWave.ToString();
    }

    public void SetBestScore()
    {
        if (_SpawnManager.score > GameManager.Instance.highScore)
        {
            GameManager.Instance.SaveHighScore(GameManager.Instance.playername, _SpawnManager.score, _SpawnManager.wave);
            _highScoreLogo.enabled = true;
        }
        else
        {
            _highScoreLogo.enabled = false;
        }
    }

    public void ShowFinalScore()
    {
        _finalName.text = _finalName.text.ToUpper() + GameManager.Instance.playername.ToUpper();
        _finalScore.text = _finalScore.text.ToUpper() + _SpawnManager.score.ToString();
        _finalWave.text = _finalWave.text.ToUpper() + _SpawnManager.wave.ToString();
    }
}

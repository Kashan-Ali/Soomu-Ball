using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum PlayStates { resume, pause, gameover };
    public PlayStates playState;

    [SerializeField] private int timeState = 1;

    [SerializeField] private GameObject hUD;
    [SerializeField] private GameObject resumeMenu;
    [SerializeField] private GameObject GameoverMenu;
    private void Update()
    {
        GamePlayState();
    }

    public void Pause()
    {
        playState = PlayStates.pause;
    }

    public void Resume()
    {
        playState = PlayStates.resume;
    }

    public void GameOver()
    {
        playState = PlayStates.gameover;
    }


    public void PauseState(bool state)
    {
        timeState = state ? 0 : 1;
        Time.timeScale = timeState;
    }

    public void GamePlayState()
    {
        switch (playState)
        {
            case PlayStates.resume:
                PauseState(false);

                //  InGame Menu triggers
                GameoverMenu.SetActive(false);
                resumeMenu.SetActive(false);
                hUD.SetActive(true);

                break;

            case PlayStates.pause:
                PauseState(true);

                //  InGame Menu triggers
                hUD.SetActive(false);
                GameoverMenu.SetActive(false);
                resumeMenu.SetActive(true);

                break;

            case PlayStates.gameover:
                PauseState(true);

                //  InGame Menu triggers
                hUD.SetActive(false);
                resumeMenu.SetActive(false);
                GameoverMenu.SetActive(true);

                break;
        }
    }

}

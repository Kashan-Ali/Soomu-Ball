using UnityEngine;
using System.Collections;

[DefaultExecutionOrder(-1)]
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        CheckSettings();

        GetComponent<AudioSource>().Play();

        //MusicPlay();
    }


    void OnDestroy()
    {

        if (instance == this)
        {
            instance = null;
        }
    }

    public void MusicPlay()
    {
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SFX/" + "Background Music");
        GetComponent<AudioSource>().Play();
    }

    void CheckSettings()
    {
        //if (PlayerPrefs.HasKey("Music"))
        //{
        //    GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music")/2;
        //}
        //else
        //{
        //    GetComponent<AudioSource>().volume = 0.3f;
        //}

        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music", 1) == 1)
            {
                GetComponent<AudioSource>().mute = false;
            }
            else
            {
                GetComponent<AudioSource>().mute = true;
            }
        }
    }

    public void Mute(bool state, bool save_state, bool save_instantly)
    {
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().mute = state;
        }

        if (save_state)
        {
            int temp_state = state ? 0 : 1;
            PlayerPrefs.SetInt("Music", temp_state);
            if (save_instantly)
            {
                PlayerPrefs.Save();
            }
        }
    }
}
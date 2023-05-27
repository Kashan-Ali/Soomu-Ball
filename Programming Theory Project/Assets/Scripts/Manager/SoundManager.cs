using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [SerializeField] AudioClip audio;

    [SerializeField] bool Debugging = false;

    public bool Allow_Sound_Play = true;

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
    }


    void OnDestroy()
    {

        if (instance == this)
        {
            instance = null;
        }
    }

    public void PlaySound(string AudioName, bool Interupt, float volume)
    {
        if (Allow_Sound_Play)
        {
            if (Resources.Load<AudioClip>("SFX/" + AudioName) != null)
            {
                //GetComponent<AudioSource>().volume = volume;
                if (!Interupt)
                {
                    audio = Resources.Load<AudioClip>("SFX/" + AudioName);
                    GetComponent<AudioSource>().PlayOneShot(audio, volume);
                }
                else
                {
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        audio = Resources.Load<AudioClip>("SFX/" + AudioName);
                        GetComponent<AudioSource>().PlayOneShot(audio, volume);
                    }
                }
            }
            else
            {
                if (Debugging)
                {
                    Debug.LogError("resourse not found");
                }
            }
        }
    }

    public void PlaySound(AudioSource AudioSource, string AudioName, bool Interupt, float volume)
    {
        if (Allow_Sound_Play)
        {
            if (Resources.Load<AudioClip>("SFX/" + AudioName) != null && AudioSource != null)
            {
                //GetComponent<AudioSource>().volume = volume;
                if (Interupt)  //old !
                {
                    audio = Resources.Load<AudioClip>("SFX/" + AudioName);
                    AudioSource.PlayOneShot(audio, volume);
                }
                else
                {
                    if (!AudioSource.isPlaying)
                    {
                        audio = Resources.Load<AudioClip>("SFX/" + AudioName);
                        AudioSource.PlayOneShot(audio, volume);
                    }
                }
            }
            else
            {
                if (Debugging)
                {
                    Debug.LogError("resourse not found");
                }
            }
        }
    }

    public void StopSound(AudioSource AudioSource)
    {
        if (AudioSource != null)
        {
            AudioSource.Stop();
        }
        else
        {
            if (Debugging)
            {
                Debug.LogError("resourse not found");
            }
        }
    }


    void CheckSettings()
    {
        //if (PlayerPrefs.HasKey("Sound"))
        //{
        //    GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound");
        //}
        //else
        //{
        //    GetComponent<AudioSource>().volume = 0.5f;
        //}

        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound", 1) == 1)
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
            PlayerPrefs.SetInt("Sound", temp_state);
            if (save_instantly)
            {
                PlayerPrefs.Save();
            }
        }
    }
}
using UnityEngine;
using FMODUnity;
using FMOD.Studio; 

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance; 
    [SerializeField]
    private EventInstance currentMusic; 

    private EventInstance musicInstance; 

    void Awake()
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
    }

    public void PlayMusic(EventReference newMusic)
    {
        if (currentMusic.isValid())
        {
            currentMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            currentMusic.release();
        }

        currentMusic = RuntimeManager.CreateInstance(newMusic);
        currentMusic.start();
    }

    public void SetMusicState(string label)
    {
        if (currentMusic.isValid())
        {
            currentMusic.setParameterByNameWithLabel("MusicState", label);
        }
    }  
}

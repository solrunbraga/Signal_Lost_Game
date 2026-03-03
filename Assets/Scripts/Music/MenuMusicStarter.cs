using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MenuMusicStarter : MonoBehaviour
{
   [SerializeField] 
   private EventReference menuMusic;

    void Start()
    {
        MusicManager.Instance.PlayMusic(menuMusic);
    }
}

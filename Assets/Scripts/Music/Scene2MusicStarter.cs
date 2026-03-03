using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Scene2MusicStarter : MonoBehaviour
{
   [SerializeField] 
   private EventReference scene2Music;

    void Start()
    {
        MusicManager.Instance.PlayMusic(scene2Music);
    }
}

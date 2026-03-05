using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Scene4MusicStarter : MonoBehaviour
{
   [SerializeField] 
   private EventReference scene4Music;

    void Start()
    {
        MusicManager.Instance.PlayMusic(scene4Music);
    }
}

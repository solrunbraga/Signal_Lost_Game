using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Scene3MusicStarter : MonoBehaviour
{
    [SerializeField] 
   private EventReference scene3Music;

    void Start()
    {
        MusicManager.Instance.PlayMusic(scene3Music);
    }
}

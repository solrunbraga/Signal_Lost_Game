using UnityEngine;
using FMODUnity; 
using FMOD.Studio; 
using System; 

public class PlayGuitarMusic : MonoBehaviour
{
    [Header("FMOD Event")]
    public EventReference musicEvent; // Drag your FMOD event here

    [Header("Particle System")]
    public ParticleSystem particleEffect; // Assign your particle system here
    
    public GameObject pressEUI;        // UI that shows "(E)"
    private bool playerInTrigger = false;
    private EventInstance musicInstance;


    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            PlayMusicAndParticlesEffect();
        }
    }

    private void PlayMusicAndParticlesEffect()
    {
        // --- FMOD Music ---
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
        }

        musicInstance = RuntimeManager.CreateInstance(musicEvent);
        RuntimeManager.AttachInstanceToGameObject(musicInstance, gameObject);
    


        musicInstance.start();

        // --- Particle Effect ---
        if (particleEffect != null)
        {
            particleEffect.gameObject.SetActive(true);
            particleEffect.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            pressEUI.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            pressEUI.SetActive(false);

        }
    }

    private void OnDestroy()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
        }
    }

}

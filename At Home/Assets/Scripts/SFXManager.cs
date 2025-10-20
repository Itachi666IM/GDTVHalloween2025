using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [HideInInspector]public float volume;
    AudioSource myAudio;
    void ManageSingleton()
    {
        int instance = FindObjectsByType<SFXManager>(FindObjectsSortMode.None).Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        ManageSingleton();
    }

    public void UpdateSFXVolume()
    {
        myAudio.volume = volumeSlider.value;
        volume = volumeSlider.value;
    }

    public void PlayAnyAudio(AudioClip audioClip)
    {
        myAudio.PlayOneShot(audioClip);
    }
}

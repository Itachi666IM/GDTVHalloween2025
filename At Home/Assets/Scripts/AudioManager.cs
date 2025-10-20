using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    AudioSource myAudio;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;
    void ManageSingleton()
    {
        int instance = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        if(instance >1)
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

    public void ChangeVolume()
    {
        myAudio.volume = volumeSlider.value;
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Story" || SceneManager.GetActiveScene().name == "End")
        {
            myAudio.clip = menuMusic;
        }
        else
        {
            myAudio.clip = gameMusic;
        }
        if(!myAudio.isPlaying)
        {
            myAudio.Play();
        }
    }
}

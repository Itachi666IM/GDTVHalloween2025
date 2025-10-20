using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] AudioClip mySound;
    SFXManager sfxManager;
    private void Awake()
    {
        sfxManager = FindAnyObjectByType<SFXManager>();
    }

    public void PlayMySound()
    {
        sfxManager.PlayAnyAudio(mySound);
    }

    public void PlayOtherSound(AudioClip sound)
    {
        sfxManager.PlayAnyAudio(sound);
    }
}

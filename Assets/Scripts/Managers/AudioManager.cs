using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource.volume = 0.3f;
    }

    public void PlaySound(AudioClip soundToPlay)
    {
        audioSource.clip = soundToPlay;
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.Play();

    }

    public void SetVolume(Slider slider)
    {
        audioSource.volume = slider.value;
    }
}

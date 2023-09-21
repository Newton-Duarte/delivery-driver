using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Audio sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource fxSource;

    [Header("Audio clips")]
    [SerializeField] AudioClip musicClip;
    [SerializeField] AudioClip fxCollect;
    [SerializeField] AudioClip fxDelivery;
    [SerializeField] AudioClip fxSuccess;
    [SerializeField] AudioClip fxFailure;
    [SerializeField] AudioClip fxImpact;

    // Start is called before the first frame update
    void Start()
    {
        PlayMusicClip(musicClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayMusicClip(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
}

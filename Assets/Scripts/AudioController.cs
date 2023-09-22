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
    [SerializeField] AudioClip fxBoost;

    void Start()
    {
        PlayMusicClip(musicClip);
    }

    void PlayMusicClip(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void CollectFX()
    {
        fxSource.PlayOneShot(fxCollect);
    }

    public void DeliveryFX()
    {
        fxSource.PlayOneShot(fxDelivery);
    }

    public void ImpactFX()
    {
        fxSource.PlayOneShot(fxImpact);
    }

    public void SuccessFX()
    {
        fxSource.PlayOneShot(fxSuccess);
    }

    public void BoostFX()
    {
        fxSource.PlayOneShot(fxBoost);
    }
}

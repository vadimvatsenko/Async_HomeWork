using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeObj : MonoBehaviour
{
    private AudioSource _audioSource;
    private PlaySoundBtn _playSoundBtn;
    private AudioClip _crySound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playSoundBtn = FindAnyObjectByType<PlaySoundBtn>();
    }

    private void OnEnable()
    {
        _playSoundBtn._playSoundAction += PokePlayCry;
    }

    private void OnDisable()
    {
        _playSoundBtn._playSoundAction += PokePlayCry;
    }
    private void PokePlayCry()
    {
        if (_crySound != null) _audioSource?.PlayOneShot(_crySound);
    }

    public void AddAudio(AudioClip crySound)
    {
        _crySound = crySound;
    }
}

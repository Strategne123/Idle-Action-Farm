using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public const int SOUND_COUNT = 7;
    private AudioSource _audioSource;
    public List<AudioClip> _clips = new List<AudioClip>();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Play(AudioSounds audio)
    {
        _audioSource.PlayOneShot(_clips[(int)audio]);
    }

    public void StepLeft()
    {
        Play(AudioSounds.GroundLeft);
    }
    public void StepRight()
    {
        Play(AudioSounds.GroundRight);
    }

    public void Mow()
    {
        Play(AudioSounds.Mow);
    }
}

public enum AudioSounds
{
    GroundLeft,
    GroundRight,
    GrassLeft,
    GrassRight,
    Mow,
    PickUp,
    Throw,
    Sell
}

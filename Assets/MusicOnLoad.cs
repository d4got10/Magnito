using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnLoad : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        StartCoroutine(TurnOnAudioCoroutine());
    }

    IEnumerator TurnOnAudioCoroutine()
    {
        float maxVolume = SoundSettings.MusicVolume;
        _audioSource.Play();
        for(float t = 0; t < 1f; t += Time.deltaTime)
        {
            _audioSource.volume = t / 1f * maxVolume;
            yield return null;
        }
        _audioSource.volume = maxVolume;
    }
}

using System;
using System.Collections;
using UnityEngine;

public class VoiceOvers : MonoBehaviour
{
    public AudioClip[] voiceOvers;
    public AudioSource audioSource;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        PlayVoiceOver(0);
    }

    public void PlayVoiceOver(int index)
    {
        audioSource.clip = voiceOvers[index];
        audioSource.PlayOneShot(audioSource.clip);
    }
    
}

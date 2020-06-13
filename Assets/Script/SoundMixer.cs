using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMixer : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] bool isMusicGoingToPlay = true;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(audioClips.Length != 0 && audioSource.isPlaying == false && isMusicGoingToPlay)
        {
            Debug.Log("Playing next song");
           audioSource.PlayOneShot (audioClips[Random.Range(0, audioClips.Length)]);
        }
    }

}

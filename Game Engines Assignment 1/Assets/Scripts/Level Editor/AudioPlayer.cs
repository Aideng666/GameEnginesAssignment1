using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        ButtonManager.clicked += PlayAudio;
        CommandInvoker.clicked += PlayAudio;
        InputPlane.clicked += PlayAudio;

    }

    private void OnDisable()
    {
        ButtonManager.clicked -= PlayAudio;
        CommandInvoker.clicked -= PlayAudio;
        InputPlane.clicked -= PlayAudio;
    }

    private void PlayAudio()
    {
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPorkchop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //for (int i = 0; i < clips.Length; i++)
        //{

        //}
    }

    // Update is called once per frame
    private void Step0()
    {
        audioSource.pitch = Random.Range(0.5f, 0.8f);
        audioSource.PlayOneShot(clips[0]);
    }
    private void Step1()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(clips[1]);
    }
    private void Oink()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[2]);
    }
    private void Scream()
    {
        audioSource.pitch = 1;
        //audioSource.volume = 1;
        audioSource.PlayOneShot(clips[3]);
    }
    private void Die()
    {
        audioSource.pitch = 1;
        //audioSource.volume = 1;
        audioSource.PlayOneShot(clips[4]);
    }
}

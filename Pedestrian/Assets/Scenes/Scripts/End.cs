using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip splat;
    public AudioClip climb;
    public AudioSource endSound;

    public GameObject text;
    void Start()
    {
        endSound = GetComponent<AudioSource>();
        text.SetActive(false);
    }

    private void bgm()
    {
        BGM.Play();
    }

    private void climbS()
    {
        endSound.PlayOneShot(climb, 0.3f);
    }

    private void splashS()
    {
        endSound.PlayOneShot(splat, .6f);
    }

    private void showText()
    {
        text.SetActive(true);
    }
}

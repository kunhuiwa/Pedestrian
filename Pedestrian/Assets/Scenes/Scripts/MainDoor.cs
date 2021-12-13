using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour
{

    public BoxCollider2D bc;
    public GameObject Open;
    public GameObject Close;

    public AudioClip OpenD;
    public AudioClip Locked;
    private AudioSource MainD;

    private void Start()
    {
        MainD = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        Open.SetActive(false);
        Close.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MainKey"))
        {
            Destroy(gameObject);
            Close.SetActive(false);
            Open.SetActive(true);

            MainD.PlayOneShot(OpenD, 1.5f);
        }
        else
        {
            MainD.PlayOneShot(Locked, 1f);
        }
    }
}
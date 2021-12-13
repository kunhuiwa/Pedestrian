using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public BoxCollider2D boxCollider;
    public GameObject OpenDoor;
    public GameObject ClosedDoor;

    public AudioClip Open;
    public AudioClip Locked;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        GameObject Key = GameObject.FindWithTag("Key");
        OpenDoor.SetActive(false);
        ClosedDoor.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            ClosedDoor.SetActive(false);
            OpenDoor.SetActive(true);
            Destroy(gameObject);

            audioSource.PlayOneShot(Open, 1.5f);
        }
        else
        {
            audioSource.PlayOneShot(Locked, 1f);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDestroy : MonoBehaviour
{
    public GameObject Key;

    private void Start()
    {
        Key.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("LockDoor") && Key.CompareTag("Key"))
        {
            Key.SetActive(false);
        }
        else if(collision.CompareTag("MainLockD") && Key.CompareTag("MainKey"))
        {
            Key.SetActive(false);
        }
        else
        {
            Key.SetActive(true);
        }
    }
}

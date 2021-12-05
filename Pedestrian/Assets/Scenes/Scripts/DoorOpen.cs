using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public static bool DoorisOpen = false;

    public BoxCollider2D boxCollider;
    public GameObject OpenDoor;
    public GameObject ClosedDoor;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        GameObject Key = GameObject.FindWithTag("Key");
        OpenDoor.SetActive(false);
        ClosedDoor.SetActive(true);

        //Debug.Log("The door is closed");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            DoorisOpen = true;

            Destroy(gameObject);
            ClosedDoor.SetActive(false);
            OpenDoor.SetActive(true);

            //Debug.Log("The door is opened");
        }
    }
}
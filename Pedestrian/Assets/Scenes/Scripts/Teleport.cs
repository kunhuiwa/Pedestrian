using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool wait = true;
    private bool moved = false;

    void Update()
    {
        if(currentTeleporter != null)
        {
            if(wait)
            {
                transform.position = currentTeleporter.GetComponent<Portal>().GetDestination().position;
                wait = false;
            }
            StartCoroutine(Wait(2));
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Portal") && !moved)
        {
            currentTeleporter = collision.gameObject;
            moved = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        moved = false;
        if (collision.CompareTag("Portal"))
        {
            if(collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        wait = true;
    }
}

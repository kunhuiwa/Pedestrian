using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRightFrame : MonoBehaviour
{
    BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == collision.gameObject.tag)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }

}

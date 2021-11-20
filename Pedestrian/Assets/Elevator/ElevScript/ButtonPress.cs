using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField]
    public static bool start = false;

    bool InRange = false;
    public SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange = false;
        }
    }

    private void Update()
    {
        if (InRange)
        {
            if (!start && Input.GetKeyDown(KeyCode.E))
            {
                sr.color = Color.green;
                start = true;
            }
            if (start && Input.GetKeyDown(KeyCode.F))
            {
                sr.color = Color.white;
                start = false;
            }
        }

        /*
        if(start)
        {
            transform.localScale = new Vector2(0.5f, 1.5f);
        }
        else
        {
            transform.localScale = new Vector2(0.5f, 1f);
        }
        */
    }
}

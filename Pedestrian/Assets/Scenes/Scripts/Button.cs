using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static bool pressed = false;
    float counter = 0;

    public GameObject ButtonOpen;
    public GameObject ButtonClose;

    SpriteRenderer sr;
    private AudioSource button;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        button = GetComponent<AudioSource>();

        ButtonOpen.SetActive(false);
        ButtonClose.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            counter++;
            pressed = true;
            sr.color = new Color(177f, 255f, 130f);
            
            if(counter == 1)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
                button.Play();
            }

            ButtonClose.SetActive(false);
            ButtonOpen.SetActive(true);
        }
    }
}
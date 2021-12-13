using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    bool KeyGrab = false;

    public AudioClip key;
    private AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null)
        {
            if (grabCheck.collider.tag == "Key" || grabCheck.collider.tag == "MainKey")
            {
              //press E to grab Key
              if (Input.GetKeyDown(KeyCode.E))
              {
                    grabCheck.collider.gameObject.transform.parent = boxHolder;
                    grabCheck.collider.gameObject.transform.position = boxHolder.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    KeyGrab = true;

                    audioS.PlayOneShot(key, 1f);
               }
                //else
                if (KeyGrab)
              {
                  if (Input.GetKeyDown(KeyCode.X))
                  {
                      grabCheck.collider.gameObject.transform.parent = null;
                      grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                      KeyGrab = false;
                  }
              }

            }

        }
    }
}

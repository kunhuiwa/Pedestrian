using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public static float vertical;
    private float speed = 8f;
    private bool isLadder = false;
    public static bool isClimbing = false;

    [SerializeField] private Rigidbody2D rbLadder;

    private Animator playerAnimation;
    private void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        //return 1/-1 depending on WS
        vertical = Input.GetAxis("Vertical");


        if (isLadder)
        {
            if (Mathf.Abs(vertical) > 0f)
            {
                isClimbing = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rbLadder.gravityScale = 0;
            rbLadder.velocity = new Vector2(rbLadder.velocity.x, vertical * speed);
        }
        else
        {
            rbLadder.gravityScale = 2.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            isLadder = false;
        }
    }
}

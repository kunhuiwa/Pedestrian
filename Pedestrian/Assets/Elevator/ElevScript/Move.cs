using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //move
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private LayerMask lm;
    public float moves = 5;
    public float jumpS = 10;

    //visuals
    //public AudioSource footstep;
    private Animator playerAnimation;
    //flip
    private bool faceRight = true;

    //respawn
    //public Vector3 respawnPoint;
    //death bar
    //public GameObject DeathDetector;

    public AudioSource footsteps;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
        footsteps = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        playerAnimation = GetComponent<Animator>();
        //respawnPoint = transform.position;
    }

    void Update()
    {
        //move
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //right
            transform.Translate(Vector2.right * Time.deltaTime * moves);
            /*
            if (!footstep.isPlaying && IsGrounded())
            {
                footstep.Play();
            }*/
        }
        /*
        else
        {
            footstep.Stop();
        }*/

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpS;
            //footstep.Stop();
            //AudioManager.PlaySound("jump");
        }

        //flip
        if (Input.GetKey(KeyCode.D) && !faceRight)
        {
            Flip();
        }
        else if (Input.GetKey(KeyCode.A) && faceRight)
        {
            Flip();
        }


        
        //Animation
        //move
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && IsGrounded())
        {
            playerAnimation.SetBool("stand", false);
        }
        else
        {
            //stand
            playerAnimation.SetBool("stand", true);
        }

        //jump
        if (!IsGrounded() && !Ladder.isClimbing && !Elevator.OnElevator)
        {
            playerAnimation.SetBool("onGround", false);
        }
        else
        {
            //stand
            playerAnimation.SetBool("onGround", true);
        }
        //climb
        if (Ladder.isClimbing)
        {
            playerAnimation.SetBool("climb", true);

            if (Mathf.Abs(Ladder.vertical) == 0f)
            {
                gameObject.GetComponent<Animator>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Animator>().enabled = true;
            }
        }
        else if (!Ladder.isClimbing)
        {
            playerAnimation.SetBool("climb", false);
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }


    //jump
    private bool IsGrounded()
    {
        RaycastHit2D rc = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, lm);
        //if not null, hit the ground
        return rc.collider != null;
    }

    private void footstep()
    {
        footsteps.Play();
    }
}

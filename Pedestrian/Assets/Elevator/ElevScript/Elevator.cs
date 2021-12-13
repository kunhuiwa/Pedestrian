using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;

    public static bool OnElevator = false;
    public Transform upperpos;
    public Transform downpos;

    bool uplimit = false;
    bool downlimit = true;
    public float speed;

    public AudioSource elevatorMove;

    private void Start()
    {
        elevatorMove = GetComponent<AudioSource>();
    }
    void Update()
    {
        ControlElevator();

        //audio
        if(OnElevator)
        {
            if(Input.GetKey(KeyCode.W) && !uplimit)
            {
                if (!elevatorMove.isPlaying)
                {
                    elevatorMove.Play();
                }
            }
            if (Input.GetKey(KeyCode.S) && !downlimit)
            {
                if (!elevatorMove.isPlaying)
                {
                    elevatorMove.Play();
                }
            }

            if (uplimit || downlimit)
            {
                elevatorMove.Stop();
            }

        }
        else if(uplimit || downlimit)
        {
            elevatorMove.Stop();
        }
    }

    void ControlElevator()
    {
        if(Vector2.Distance(player.position, transform.position)<1.3f)
        {
            OnElevator = true;
            if (Input.GetKey(KeyCode.W) && !uplimit)
            {
                transform.position = Vector2.MoveTowards(transform.position, upperpos.position, speed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(KeyCode.S) && !downlimit)
            {
                transform.position = Vector2.MoveTowards(transform.position, downpos.position, speed * Time.deltaTime * 2f);
            }

            if(transform.position.y >= upperpos.position.y)
            {
                uplimit = true;
            }
            else if(transform.position.y <= downpos.position.y)
            {
                downlimit = true;
            }
            else
            {
                uplimit = false;
                downlimit = false;
            }
        }
        else
        {
            OnElevator = false;
            transform.position = Vector2.MoveTowards(transform.position, downpos.position, speed * Time.deltaTime);
        }
        
    }
}

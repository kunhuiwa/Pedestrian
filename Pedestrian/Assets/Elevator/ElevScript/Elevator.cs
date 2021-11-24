using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;

    public Transform upperpos;
    public Transform downpos;

    bool uplimit = false;
    bool downlimit = true;
    public float speed;

    void Update()
    {
        ControlElevator();
    }

    void ControlElevator()
    {
        if(Vector2.Distance(player.position, transform.position)<1f)
        {
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
            transform.position = Vector2.MoveTowards(transform.position, downpos.position, speed * Time.deltaTime);
        }
        


        }
}

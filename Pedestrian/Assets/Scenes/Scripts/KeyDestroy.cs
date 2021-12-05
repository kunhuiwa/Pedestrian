using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDestroy : MonoBehaviour
{
    void Update()
    {
        if(DoorOpen.DoorisOpen)
        {
            Destroy(gameObject);
        }
    }
}

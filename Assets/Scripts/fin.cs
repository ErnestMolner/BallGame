using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fin : MonoBehaviour
{
     public Canvas canvas;

       
    void OnTriggerEnter(Collider other)
    {
        canvas.enabled = !canvas.enabled;
                Time.timeScale = 0;
           
    }
}

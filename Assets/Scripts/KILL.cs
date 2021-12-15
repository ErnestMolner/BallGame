using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class KILL : MonoBehaviour
{

    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemigo; 
    private bool dentro = false;

    int lifes;
   

    public Canvas canvas;

    int cont;

    // Use this for initialization
    void Start()
    {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        lifes = 5;
   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = false;
        }
    }
    // Update is called once per frame
    void Update()
    {        Debug.Log(lifes);

        if (!dentro)
        {
            enemigo.destination = jugador.position;
        }
        if (dentro)
        {
            enemigo.destination = this.transform.position;
        }
    }

    void OnCollisionEnter(Collision other)
    { 

      if (other.gameObject.CompareTag("Kill") )
        {
              lifes=lifes-1;
            Debug.Log(lifes);

             Destroy(gameObject);
           
           

         }
         if (other.gameObject.CompareTag("Kill") && lifes == 0 )
        {
            Destroy(gameObject);
            
            canvas.enabled = !canvas.enabled;
            Time.timeScale = 0;
           



        }

    }
}


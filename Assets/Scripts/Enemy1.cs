using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemigo;
    private bool dentro = false;

    int life;

    // Use this for initialization
    void Start()
    {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        life = 1;
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
    {

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
           life= life - 1;
            Debug.Log(life);

         }
         if (other.gameObject.CompareTag("Kill") && life == 0 )
        {
            Destroy(gameObject);

        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    GameObject prefab;
    GameObject projectile;
    void Start ()
    {
        prefab = Resources.Load("projectile") as GameObject;
    }
    private void Update()
    {
            if(Input.GetMouseButtonDown(0))
        {
            projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;


            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 10;
            DestroyObjectDelayed();
           // StartCoroutine(WaitBeforeShow());
        }
   
    

    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 1 seconds after loading the object
        Destroy(projectile, 1);
    }

}
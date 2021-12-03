using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform p;
    [SerializeField] private Transform r;

    void OnTriggerEnter(Collider other)
    {
        p.transform.position = r.transform.position;
    }
}

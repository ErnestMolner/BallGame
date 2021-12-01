using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Vector3 positionCamera;
    public Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
        positionCamera = camera.transform.position;
    }

    void Update()
    {
        GoToTarget();
    }

    public void GoTo(Vector3 position)
    {
        positionCamera = Vector3.Lerp(positionCamera, position, Time.deltaTime);
    }

    public void GoToTarget()
    {
        Vector3 newpos = positionCamera;
        camera.transform.position = newpos;
    }
}
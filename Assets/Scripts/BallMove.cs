using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody rb ;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    public float dashSpeed = 5.0f;
    public float maxSpeed = 5.0f;
    public float dashTime = 3.0f;
    private float timer = 0.0f;
    private Vector3 direction;

    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float seconds = timer % 60;

        //Jump Signal
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (seconds > dashTime && rb.velocity.magnitude < maxSpeed &&(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q)))
        {
            timer = 0.0f;
            Dash();
        }
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        direction = Quaternion.AngleAxis(camera.rotation.eulerAngles.y, Vector3.up) * direction;

        rb.AddForce(direction * speed);
    }

    private void Jump() 
    {
        rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
    }

    private void Dash()
    {
        rb.AddForce(direction * dashSpeed, ForceMode.Impulse);
    }

    private void OnApplicationFocus(bool focus) 
    {
        if (focus) 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

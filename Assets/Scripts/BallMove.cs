using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // private Rigidbody rb ;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private float limit;
    private float speed = 5.0f;

    //salta...........
    public float Jumpv = 0.2f;
    public Rigidbody rb;
    public float thrust = 5;
    bool m_isGrounded;
    bool b_isGrounded;


   public Transform camera;

    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        m_isGrounded = true;
        b_isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded == true)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && b_isGrounded == true)
        {
            JumpProva();
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }*/
    }

    public void Jump()
    {
        m_isGrounded = false;
        //  rb.AddForce(0, thrust, 0, ForceMode.Impulse);
        rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
    }

    public void JumpProva()
    {
        b_isGrounded = false;
       // rb.AddForce(plane, 0.5f);
    }

    private void FixedUpdate()
    {

       // rb.AddForce(new Vector3(horizontalInput, 0.0f, verticalInput) * speed);

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        direction = Quaternion.AngleAxis(camera.rotation.eulerAngles.y, Vector3.up) * direction;

        rb.AddForce(direction * speed);
        /*
        if (jumpKeyWasPressed)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }*/
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            m_isGrounded = true;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            b_isGrounded = true;
            Debug.Log("Tocat");
        }
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

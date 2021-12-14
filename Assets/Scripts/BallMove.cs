using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class BallMove : MonoBehaviour
{
    // private Rigidbody rb ;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private float limit;
    private float speed = 10.0f;

    //salta...........
    public float Jumpv = 0.2f;
    public Rigidbody rb;
    public float thrust = 10;
    bool m_isGrounded;
    bool b_isGrounded;


   public Transform camera;
   public Canvas canvas;

    public  bool d = false;


    [SerializeField] private Transform p;
    [SerializeField] private Transform r;

    


    public float t_s = 0.0f;
        
    public float t_e = 0.0f;


    public Image life;
    public float va;
    public float vm;

    public float TimeToDestroy = 3f;

    public Text ContadorText;
    public int TiempoText;

    //camera zoom
/*
    int zoom = 20;
    int normal = 60;
    float smooth = 5;

    private bool isZoomed = false;
*/


    // Start is called before the first frame update
    void Start()
    {

       
        rb = GetComponent<Rigidbody>();
        m_isGrounded = true;
        b_isGrounded = true;
        d = false;

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
        life.fillAmount = va / vm;
        /*
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(Input.mousePosition);
            isZoomed = !isZoomed;
        }

        if(isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);

        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
        */
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


        if (other.gameObject.tag == "Enemy"  )
        {
            va = va - 25.5f ;
        }


       
        


       

        if (other.gameObject.tag == "Enemy" && va <= 0 && !d)
        {

            //d = true;

            // canvas.enabled = !canvas.enabled;

            //Destroy(gameObject);

            StartCoroutine(WaitBeforeShow());
         

           // va = 100;


        }

        IEnumerator WaitBeforeShow()
        {
            d = true;
            canvas.enabled = !canvas.enabled;
 
            yield return new WaitForSeconds(3);
          
         
       

            p.transform.position = r.transform.position;
            va = 100;
            canvas.enabled = !canvas.enabled;
            d = false;
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

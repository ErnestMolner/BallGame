using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{
    float X;
    float Y;

    // Start is called before the first frame update
      void Start()
       {

       }
    void prova()
    {

        X = Input.mousePosition.x;
        Y = Input.mousePosition.y;


        this.GetComponent<RectTransform>().position = new Vector2(
            (X / Screen.width) * 20 + (Screen.width / 2),
            (Y / Screen.height) * 20 + (Screen.height / 2));
    }
    // Update is called once per frame
    void Update()
     {

        prova();


     }
}

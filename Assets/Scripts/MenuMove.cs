using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour
{
    float X;
    float Y;

    [SerializeField] float mq;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        X = Input.mousePosition.x;
        Y = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
            (X / Screen.width) * mq + (Screen.width / 2),
            (Y / Screen.height) * mq + (Screen.height / 2));

    }
}

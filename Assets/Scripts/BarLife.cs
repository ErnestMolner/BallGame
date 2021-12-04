using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class BarLife : MonoBehaviour
{

    public Image life;
    public float va;
    public float vm;

    // Update is called once per frame
    void Update()
    {
        life.fillAmount = va / vm;
    }
}

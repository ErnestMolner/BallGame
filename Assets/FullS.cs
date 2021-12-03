using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FullS : MonoBehaviour
{



    public void Fullscene (bool is_fullscene)
    {
        Screen.fullScreen = is_fullscene;

        Debug.Log("Fullscreen : " + is_fullscene);
    }

    public void Low(bool low)
    {




        Screen.SetResolution(720, 360 , low);

        Debug.Log("Low : " + low);



    }

    public void _4K(bool is_4k)
    {




        Screen.SetResolution(3840,2160, is_4k);

        Debug.Log("4K : " + is_4k);



    }


    public void FullHD(bool is_fullHD)
    {
        

    

            Screen.SetResolution(1920, 1080, is_fullHD);

            Debug.Log("FullHD : " + is_fullHD);
        

        
    }


    public void HD(bool is_HD)
    {


        Screen.SetResolution(1280, 720, is_HD);

        Debug.Log("FHD : " + is_HD);
    }
      
    
}

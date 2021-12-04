using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class M : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public Text label;

    public string[] labels = { "Hooray!", "When it's finished!", "Hello World!", "Subscribe" };

    public AudioSource musicSource;
    public Text musicText;

    public AudioSource soundSource;
    public Text soundText;
    public Canvas canvas;

    public bool isPauseMenu = false;
    public bool n = false;

    [SerializeField] private Transform p;
    [SerializeField] private Transform r;

    //private BallMove de;
   // public GameObject pl;


    void Start()
    {
        ChangeText();
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
            CheckMusicText();
        }
        if (PlayerPrefs.HasKey("soundVolume"))
        {
            soundSource.volume = PlayerPrefs.GetFloat("soundVolume");
            CheckSoundText();
        }
      //  de = pl.GetComponent<BallMove>();
    }

    void Update()
    {

     

       

        if (isPauseMenu && Input.GetKeyDown(KeyCode.Escape) /*&& de.d*/)
        {
          
            canvas.enabled = !canvas.enabled;
            Time.timeScale = 0;
            if(canvas.enabled)
            {
                Time.timeScale = 0;

            }

            if(!canvas.enabled)
            {
                Time.timeScale = 1;
            }
            // HideOptions();

        }






        /*
                else (!isPauseMenu || !Input.GetKeyDown(KeyCode.Escape))
                {

                    //canvas.enabled = !canvas.enabled;
                    Time.timeScale = 1;

                }*/


    }

    public void ChangeText()
    {
        if (label != null)
        {
            label.text = labels[Random.Range(0, labels.Length)];
        }
    }

    public void BackToGame()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = 1;
        n = false;
    }

    public void BackToGame2()
    {
        canvas.enabled = !canvas.enabled;
          p.transform.position = r.transform.position;

    }

    public void LoadLevel(int index)
    { Time.timeScale = 1;
        n = false;
        SceneManager.LoadScene(index, LoadSceneMode.Single);
       
    }

    public void ShowOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void HideOptions()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        ChangeText();
    }

    public void SwitchMusic()
    {
        if(musicSource.volume > 0)
        {
            musicSource.volume = 0;
        }
        else
        {
            musicSource.volume = 1;
        }
        CheckMusicText();
        PlayerPrefs.SetFloat("musicVolume", musicSource.volume);
    }

    public void CheckMusicText()
    {
        if (musicSource.volume > 0)
        {
            musicText.text = "Music: ON";
        }
        else
        {
            musicText.text = "Music: OFF";
        }
    }

    public void SwitchSounds()
    {
        if (soundSource.volume > 0)
        {
            soundSource.volume = 0;
        }
        else
        {
            soundSource.volume = 1;
        }
        CheckSoundText();
        PlayerPrefs.SetFloat("soundVolume", soundSource.volume);
    }

    public void CheckSoundText()
    {
        if (soundSource.volume > 0)
        {
            soundText.text = "Sound: ON";
        }
        else
        {
            soundText.text = "Sound: OFF";
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

}

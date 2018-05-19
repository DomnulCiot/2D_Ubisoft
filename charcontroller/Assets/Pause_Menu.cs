using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject Pause_UI;
    public GameObject Pause_UI_2;
	// Update is called once per frame

        void Awake ()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        Pause_UI.SetActive(false);
    }
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
	}

    public void BackToMenu ()
    {
        Pause_UI.SetActive(true);
        Pause_UI_2.SetActive(false);
    }

    public void EnterOpt ()
    {
        Pause_UI.SetActive(false);
        Pause_UI_2.SetActive(true);
    }

    void Pause ()
    {
        Pause_UI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

   public void Resume ()
    {
        Pause_UI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false; 
    }

    public void Load_MainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit ()
    {
        Application.Quit();
    }

}

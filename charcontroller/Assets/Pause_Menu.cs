using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject Pause_UI;
	// Update is called once per frame
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

    public static void Quit ()
    {
        Application.Quit();
    }

}

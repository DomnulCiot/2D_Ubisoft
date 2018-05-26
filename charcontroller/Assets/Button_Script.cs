using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour {

    bool Setting = false;
    public GameObject main_menu;
    public GameObject settings_menu;
	public void Play ()
    {
        SceneManager.LoadScene("CutScene");

    }

    public void Options ()
    {
        Setting = true;
        main_menu.SetActive(false);
        settings_menu.SetActive(true);
    }

    public void Quit ()
    {
        Application.Quit();
    }
    public void Back ()
    {
        Setting = false;
        main_menu.SetActive(true);
        settings_menu.SetActive(false);
    }
    public void Full_Screen (bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }
}

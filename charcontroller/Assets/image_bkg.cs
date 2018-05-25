using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class image_bkg : MonoBehaviour {

    public Sprite[] Img;
    public int count = 0;
    public Image img;
	
	

   public void NextImg ()
    {
        count++;
        if (count<2)
        img.sprite = Img[count];
        else
        if (count == 2)
        {
            Debug.Log("monis");
            SceneManager.LoadScene("yes");
        }
            
    }
}

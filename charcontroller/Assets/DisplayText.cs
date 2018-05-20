using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour {

    private Queue<string> sentences;
    public Canvas canvas;
    void Start()
    {
        sentences = new Queue<string>();
        canvas.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            canvas.enabled = true;
            Debug.Log("Sunt un Elder GAY");
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            canvas.enabled = false;
            Debug.Log("Sunt un Elder GAY");
        }
    }
}

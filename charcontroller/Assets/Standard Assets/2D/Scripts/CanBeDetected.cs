using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeDetected : MonoBehaviour
{

    public bool PlayerHidden = false;
    public bool gotoplayer = false;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !PlayerHidden)
        {
            Debug.Log("Detected Player");
            gotoplayer = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !PlayerHidden)
        {
            gotoplayer = false;
        }

    }
}

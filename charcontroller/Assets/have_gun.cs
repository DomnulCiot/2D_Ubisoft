using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class have_gun : MonoBehaviour {

    public GameObject Gun;
    public bool having_gun;
    float TimeSearch;

    void FindGun()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Gun");
            if (Search != null)
                Gun = Search;
            TimeSearch = Time.time + 0.5f;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Gun == null )
        {
            FindGun();
            return;
        }
        Gun.SetActive(having_gun);
	}
}

using UnityEngine.UI;
using UnityEngine;

public class Hearh_UI : MonoBehaviour {

    public Sprite[] Health;
    public Image Health_UI;
    public Player_Health player;
    public Text health;
    float TimeSearch = 0;
    void Start ()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }

    void FixedUpdate ()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }
        if (player.curHealth==100)
        Health_UI.sprite = Health[5];
        else
        {
            Health_UI.sprite = Health[player.curHealth / 20 +1];
        }
        health.text = (player.curHealth.ToString());
    }

    void FindPlayer ()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                player = Search.GetComponent<Player_Health>();
            TimeSearch = Time.time + 0.5f;
        }
    }
           
}

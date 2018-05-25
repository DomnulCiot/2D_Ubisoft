using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class Player_Health : MonoBehaviour
{

    public int curHealth;
    public int maxHealth = 100;
    private Rigidbody2D rb2D;
    float TimeSearch = 0;
    public float posx;
    public float posy;
    public Transform Player;
    public float time;
    float timer = 0;
    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;
        rb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        posx = Player.position.x;
        posy = Player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2D == null)
        {
            FindPlayer();
            return;
        }
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (curHealth <= 0)
           Die();
        if (curHealth <= 0)
            if (timer < time)
                timer += 0.5f;
    }


    void Die()
    {

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Player.position = new Vector2(posx, posy);
        if (timer ==time)
        Game_Master.killPlayer(gameObject);


    }

    public void Damage(int Dmg)
    {
        curHealth -= Dmg;
    }

    public IEnumerator KnockBack(float Duration, float PowerOfKnockBack, Vector3 DirectionOfKnockBack)
    {
        float timer = 0;
        while (Duration >= timer)
        {
            timer += Time.deltaTime;
            rb2D.AddForce(new Vector3(DirectionOfKnockBack.x * 0 - 700, DirectionOfKnockBack.y * PowerOfKnockBack, DirectionOfKnockBack.z));
        }
        yield return 0;
    }

    void FindPlayer()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                rb2D = Search.GetComponent<Rigidbody2D>();
            TimeSearch = Time.time + 0.5f;
        }
    }
}

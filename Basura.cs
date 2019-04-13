using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{
    public float speed;
    GameObject player;
    Rigidbody2D rb2d;
    Vector3 target, dir;
    float secondsCount, secondsCounter;
    private GameObject healthbar, healthbarVillano;
    GameObject villano;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        speed = 5;
        if (player != null)
        {
            target = player.transform.position;
            dir = (target - transform.position).normalized;
        }
        secondsCount = 2;
        secondsCounter = 0;
        healthbar = GameObject.Find("HealthBar");
        villano = GameObject.Find("Villano");
        healthbarVillano = GameObject.Find("HealthBarVillano");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != Vector3.zero)
        {
            rb2d.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
            
        }
        secondsCounter += Time.deltaTime;
        if (secondsCounter>secondsCount)
        {
            speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && speed>0)
        {
            collision.GetComponent<FightherController>().GetComponent<SpriteRenderer>().color = Color.red;
            healthbar.SendMessage("TakeDamage", 10);
            collision.GetComponent<FightherController>().GetComponent<SpriteRenderer>().color = Color.blue;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && speed ==0)
        {
            collision.GetComponent<FightherController>().GetComponent<SpriteRenderer>().color = Color.black;
            if (Input.GetKeyDown(KeyCode.C))
            {
                collision.GetComponent<FightherController>().GetComponent<SpriteRenderer>().color = Color.blue;
                healthbarVillano.SendMessage("TakeDamage", 5);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.GetComponent<FightherController>().GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    IEnumerable Stay(float seconds)
    {
        rb2d.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        print("hola");
    }

}

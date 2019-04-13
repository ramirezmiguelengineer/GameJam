using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VillanoMovement : MonoBehaviour
{
    public float speed;
    public GameObject puntos, player;
    public float life;
    Vector3 inicialposicion, target;
    public Canvas cnvw;
    /* Variables de ataque*/
    public GameObject bolaPrefab;
    public float atckSpeed;
    bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        player = GameObject.FindGameObjectWithTag("Player");
        //target = player.GetComponent<Transform>();
        inicialposicion = transform.position;
        atckSpeed = 1f;
        life = 100;
        cnvw.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntos.transform.position, speed * Time.deltaTime);
        target = inicialposicion;
        if (Vector2.Distance(this.transform.position, player.transform.position)>3)
        {
            if (!attacking)
            {
                StartCoroutine(Attack(atckSpeed));
            }
            
        }
        if (life == 0)
        {
            cnvw.enabled = true;
        }
        if (life == 50)
        {
            atckSpeed = 0.5f;
        }

        
    }
    IEnumerator Attack(float seconds)
    {
        attacking = true;
        Instantiate(bolaPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(seconds);
        attacking = false;
    }
}

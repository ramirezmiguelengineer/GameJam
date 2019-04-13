using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FightherController : MonoBehaviour
{
    // Start is called before the first frame update
    int speed;
    public float padding;
    public float life;
    public Canvas cnvl;
    Renderer rnd;
    void Start()
    {
        speed = 7;
        padding = 1;
        rnd = GetComponent<Renderer>();
        life = 100;
        cnvl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movimientos();
        ComprobarVida();
    }
    void Movimientos()
    {
        float vInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, vInput * speed * Time.deltaTime, 0);

        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3( hInput * speed * Time.deltaTime,0, 0);

        //Posicion
        float newX = Mathf.Clamp(transform.position.x, -10+padding, 10 - padding);
        float newY = Mathf.Clamp(transform.position.y, -10 + padding, 10 - padding);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    void ComprobarVida()
    {
        if (life<=0)
        {
            cnvl.enabled = true;
        }
    }
}

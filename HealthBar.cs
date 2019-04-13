using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Image health,damage;
    GameObject jugador;
    float pointLife, maxPointLife = 100f;
    // Start is called before the first frame update
    void Start()
    {
        pointLife = maxPointLife;
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float cantidad)
    {
        pointLife = Mathf.Clamp(pointLife - cantidad, 0f, maxPointLife);
        health.transform.localScale = new Vector2(pointLife / maxPointLife, 1);
        jugador.GetComponent<FightherController>().life -= 10;
    }
}

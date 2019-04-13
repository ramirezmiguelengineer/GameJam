using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarVillano : MonoBehaviour
{
    public Image health, damage;
    public GameObject villano;
    float pointLife, maxPointLife = 100f;
    // Start is called before the first frame update
    void Start()
    {
        pointLife = maxPointLife;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float cantidad)
    {
        pointLife = Mathf.Clamp(pointLife - cantidad, 0f, maxPointLife);
        health.transform.localScale = new Vector2(pointLife / maxPointLife, 1);
        villano.GetComponent<VillanoMovement>().life -= 5;
    }
}

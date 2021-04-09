using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    bool dead = false;
    public Slider slider;
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }


    void Update()
    {

    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0 )
        {
            health -= damage;
        }

        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }


}

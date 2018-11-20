using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHealth : MonoBehaviour {
    private int health;
    public Image healthBar;

    // Use this for initialization
    void Start () {
        health = 99;

    }

    public void gotHit()
    {
        health -= 33;
        healthBar.fillAmount = health / 99f;
        if (health <= 0)
        {

           ( (GameObject)GameObject.FindGameObjectWithTag("Player") ).GetComponent<PlayerControll>().addScore("enemy3");
            Destroy(gameObject);
        }

    }
}

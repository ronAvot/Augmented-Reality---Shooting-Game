using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour {
	[HideInInspector]
    public GameObject player;

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("enemy1"))
        {            
            player.GetComponent<PlayerControll>().addScore("enemy1");
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("enemy2"))
        {
            player.GetComponent<PlayerControll>().addScore("enemy2");
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("enemy3"))
        {
            other.gameObject.GetComponent<bossHealth>().gotHit();
           
        }

        
        Destroy(gameObject);
    }


}

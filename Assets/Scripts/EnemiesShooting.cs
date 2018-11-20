using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShooting : MonoBehaviour {

    public float fireTime = 2f;

    // Use this for initialization
    void Start () {
        //    InvokeRepeating("Fire", fireTime, fireTime);
        StartCoroutine("startFire");
    }

    IEnumerator Fire()
    {
		while (true) 
		{
			if (BulletPooler.current == null)
				print ("null");
			GameObject obj = BulletPooler.current.GetPooledObject ();

			if (obj == null)
				yield break;

			if (gameObject.tag == "enemy2")
				obj.transform.localScale = new Vector3 (0.02f, 0.02f, 0.1f); 
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation; 
			obj.SetActive (true);

			yield return new WaitForSeconds (4f);
		}
    }

    IEnumerator startFire()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine("Fire");

    }

    
    
}

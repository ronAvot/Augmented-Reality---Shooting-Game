using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControll : MonoBehaviour {

    [HideInInspector]
    public Transform target;
   // private float speed = 1f;
	// Use this for initialization
	void Start () {

        transform.LookAt(target);
    }
	 
	// Update is called once per frame
	void Update () {
        // Vector3 targetDir = target.position - transform.position;
         //float step = speed * Time.deltaTime;
        // Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.LookAt(target);
		transform.rotation = new Quaternion ( 0f, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
      //  transform.rotation = Quaternion.LookRotation(newDir);

        

    }
}

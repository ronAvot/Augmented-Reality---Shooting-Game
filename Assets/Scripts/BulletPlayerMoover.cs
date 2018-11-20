using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerMoover : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
		StartCoroutine("disableTime");
	}

	IEnumerator disableTime()
	{
		yield return new WaitForSeconds(2f);
		this.gameObject.SetActive(false);
	}
	

}

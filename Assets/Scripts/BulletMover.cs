using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    public float speed;


    void OnEnable()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        StartCoroutine("disableTime");
    }

    IEnumerator disableTime()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour {

    public static BulletPooler current;
    public GameObject poolledObject;
    public int pooledAmount = 40;
    public bool willGrow = false;

    List<GameObject> pooledObjects;

    private void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start () {

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if(willGrow)
        {
            GameObject obj = (GameObject)Instantiate(poolledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
    // Update is called once per frame
    void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScreen : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
       
#if UNITY_IPHONE
		RectTransform rect = GetComponent<RectTransform>();
        rect.rotation = new Quaternion(0, 0, -180, 0);
        rect.localScale = new Vector3(-1, 1, 1);
#endif

    }


}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class webcamTexture : MonoBehaviour {

	public GameObject webCameraPlane;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		WebCamTexture webCameraTexture = new WebCamTexture();
		webCameraPlane.GetComponent<Image>().material.mainTexture = webCameraTexture;
		webCameraTexture.Play();
	}

	// Use this for initialization
	void Start () {
		//Input.gyro.enabled = true;


	/*	WebCamTexture webCameraTexture = new WebCamTexture();
		webCameraPlane.GetComponent<Image>().material.mainTexture = webCameraTexture;
		webCameraTexture.Play();*/
	

	}

	// Update is called once per frame
	void Update () {

	}


   
}


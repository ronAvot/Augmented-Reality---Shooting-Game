using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour {

	AudioSource audioClip;

	void OnEnable()
	{
		if (audioClip != null)
		audioClip.Play ();
	}

	void Start () 
	{
		audioClip = (AudioSource)this.gameObject.GetComponent<AudioSource> ();

		if (this.gameObject.tag == "Bullet") {
			if (audioClip != null)
				audioClip.Play ();
		}
	}


}

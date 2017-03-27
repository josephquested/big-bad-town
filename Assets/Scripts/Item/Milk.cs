using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour {
	public AudioClip winBGM;
	bool triggered = false;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (!triggered)
		{
			if (collider.tag == "Player")
			{
				GetComponent<SpriteRenderer>().enabled = false; 
				triggered = true;
				collider.gameObject.GetComponent<GameTimer>().StopTimer();
				AudioSource BGM = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
				BGM.clip = winBGM;
				BGM.Play();
				GetComponent<EndFlash>().enabled = true;
			}
		}
	}
}

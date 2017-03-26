using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour {
	public AudioClip winBGM;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			AudioSource BGM = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
			BGM.clip = winBGM;
			BGM.Play();
			print("win!");
		}
	}
}

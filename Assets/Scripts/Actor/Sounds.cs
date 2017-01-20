using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {
	private AudioSource audioSource;

 	public AudioClip damaged;

	void Start () {
		audioSource = this.GetComponent<AudioSource>();
	}

	public void Damaged () {
		audioSource.clip = damaged;
		audioSource.Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAudio : MonoBehaviour
{
	private AudioSource audioSource;

	[SerializeField] private AudioClip hurt;

	void Start ()
	{
		audioSource = this.GetComponent<AudioSource>();
	}

	public void Hurt ()
	{
		audioSource.clip = hurt;
		audioSource.Play();
	}
}

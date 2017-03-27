using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {
	AudioSource bgmAudio;

	void Start ()
	{
		bgmAudio = GetComponent<AudioSource>();
	}

	public void Activate ()
	{
		bgmAudio.Play();
		if (bgmAudio.isPlaying)
		{
			print("i am playing");
		}
	}
}

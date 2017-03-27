using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {
	AudioSource bgmAudio;
	public AudioClip[] clips;

	void Start ()
	{
		bgmAudio = GetComponent<AudioSource>();
	}

	public void Activate ()
	{
		StartCoroutine(BGMRoutine());
	}

	IEnumerator BGMRoutine ()
	{
		bgmAudio.Play();
		while (bgmAudio.isPlaying)
		{
			yield return null;
		}
		bgmAudio.clip = clips[Random.Range(0, clips.Length)];
		StartCoroutine(BGMRoutine());
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour {
	AudioSource audioSource;

	public Collider2D explosionCollider;
	public AudioClip explodeSound;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	public void Explode () {
		StartCoroutine(ExplodeCoroutine());
	}

	IEnumerator ExplodeCoroutine () {
		GetComponent<Animator>().SetTrigger("explode");
		audioSource.clip = explodeSound;
		audioSource.Play();
		explosionCollider.enabled = true;
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}

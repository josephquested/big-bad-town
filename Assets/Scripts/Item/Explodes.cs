using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour {
	AudioSource audioSource;

	public Collider2D explosionCollider;
	public AudioClip explodeSound;
	public bool explosionOnly;
	public bool onTouch;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	public void Explode () {
		if (GetComponent<Rigidbody2D>() != null) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
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

	void OnTriggerEnter2D (Collider2D collider) {
		if (onTouch) {
			if (collider.tag == "Player" || collider.tag == "Enemy") {
				Explode();
			}

			if (collider.gameObject.GetComponent<Explodes>() != null) {
				Explodes explodes = collider.gameObject.GetComponent<Explodes>();
				explodes.Explode();
				Explode();
			}

			if (collider.gameObject.layer == LayerMask.NameToLayer("Solid")) {
				Explode();
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour {
	public Collider2D explosionCollider;

	public void Explode () {
		StartCoroutine(ExplodeCoroutine());
	}

	IEnumerator ExplodeCoroutine () {
		GetComponent<Animator>().SetTrigger("explode");
		explosionCollider.enabled = true;
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}

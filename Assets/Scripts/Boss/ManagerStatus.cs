using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStatus : Status {
	public BangBarrelBox[] bangBarrelBoxes;
	public GameObject fakeWall;
	public GameObject barrier;

	void Awake () {
		if (PlayerPrefs.GetInt(gameObject.name) == 1) {
			Destroy(gameObject);
		}
	}

	public override void Die () {
		foreach (BangBarrelBox box in bangBarrelBoxes) {
			box.enabled = false;
		}

		audioSource.clip = dieSound;
		audioSource.Play();
		StartCoroutine(DeathCoroutine(12f));
	}

	IEnumerator DeathCoroutine (float duration) {
		GetComponent<Animator>().SetBool("moving", false);
		GetComponent<Animator>().SetBool("attack", false);
		GetComponent<Animator>().SetTrigger("die");

		GetComponent<ManagerController>().canMove = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		for (float i = 0; i < duration; i++) {
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.black;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.white;
		}

		if (GetComponent<Drops>() != null) {
			GetComponent<Drops>().AttemptDrop();
		}

		if (singleSpawn) {
			PlayerPrefs.SetInt(spawner.name, 1);
		}

		Destroy(fakeWall);
		Destroy(barrier);

		PlayerPrefs.SetInt(gameObject.name, 1);
		Destroy(gameObject);
	}
}

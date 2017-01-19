using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	public int baseHealth;
	public int health;
	public bool invulnerable;

	// Sounds sounds;

	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
		spriteRenderer = GetComponent<SpriteRenderer>();
		// actorAudio = GetComponent<Sounds>();
	}

	public void Damage (int damage) {
		if (invulnerable) return;
		health -= damage;
		// sounds.Damaged();
		StartCoroutine(InvulnerableCoroutine());

		if (health <= 0)
		{
			Die();
		}
	}

	IEnumerator InvulnerableCoroutine () {
		float duration = 1;
		for (float i = 0; i < duration; i++) {
			invulnerable = true;
			spriteRenderer.color = Color.black;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.1f);
		}
		invulnerable = false;
	}

	public virtual void Die () {
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<Collider2D>().enabled = false;
	}
}

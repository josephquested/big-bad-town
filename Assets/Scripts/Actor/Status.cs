using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	protected SpriteRenderer spriteRenderer;
	protected Collider2D actorCollider;
	Sounds sounds;

	public int baseHealth;
	public int health;
	public bool invulnerable;


	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		actorCollider = GetComponent<Collider2D>();
		sounds = GetComponent<Sounds>();
	}

	public void Damage (int damage) {
		if (invulnerable) return;
		health -= damage;
		sounds.Damaged();
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
		actorCollider.enabled = false;
	}
}

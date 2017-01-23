using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	[HideInInspector] public GameObject spawner;
	[HideInInspector] public bool singleSpawn;

	protected SpriteRenderer spriteRenderer;
	protected Collider2D actorCollider;
	protected AudioSource audioSource;

	public int baseHealth;
	public int health;
	public bool invulnerable;
	public AudioClip dieSound;
	public AudioClip damagedSound;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		actorCollider = GetComponent<Collider2D>();
		audioSource = GetComponent<AudioSource>();
	}

	public void Damage (int damage) {
		if (invulnerable) return;
		health -= damage;
		audioSource.clip = damagedSound;
		audioSource.Play();
		StartCoroutine(InvulnerableCoroutine());

		if (health <= 0)
		{
			Die();
		}
	}

	IEnumerator InvulnerableCoroutine () {
		float duration = 2;
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

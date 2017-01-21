using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	AudioSource audioSource;
	int direction;

	public GameObject bulletPrefab;
	public bool shooting;
	public Sprite[] sprites;
	public int damage;
	public int knockback;
	public float attackSpeed;
	public float bulletSpeed;
	public int weight;
	public AudioClip attackSound;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		UpdateSprite();
	}

	public void Attack () {
		spriteRenderer.enabled = true;
		StartCoroutine(ShootCoroutine());
	}

	IEnumerator ShootCoroutine () {
		shooting = true;
		float duration = attackSpeed;

		while (duration >= 0) {
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}

		Fire();
		duration = attackSpeed;

		while (duration >= 0) {
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}

		spriteRenderer.enabled = false;
		shooting = false;
	}

	void Fire () {
		var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		Vector2 vector = GetVector(transform.parent.gameObject.GetComponent<Animates>().direction);
		bullet.GetComponent<Bullet>().ReceiveData(damage, transform, knockback);
		bullet.GetComponent<Rigidbody2D>().AddForce(vector * bulletSpeed);

		audioSource.clip = attackSound;
		audioSource.Play();
	}

	void UpdateSprite () {
		direction = transform.parent.gameObject.GetComponent<Animates>().direction;
		spriteRenderer.sprite = sprites[direction];
		if (direction == 0) transform.localPosition = new Vector2(0, 1);
		if (direction == 1) transform.localPosition = new Vector2(0.85f, 0);
		if (direction == 2) transform.localPosition = new Vector2(0, -1);
		if (direction == 3) transform.localPosition = new Vector2(-0.85f, 0);
	}

	Vector2 GetVector (int direction) {
		if (direction == 0) return new Vector2(0, 1);
		if (direction == 1) return new Vector2(1, 0);
		if (direction == 2) return new Vector2(0, -1);
		return new Vector2(-1, 0);
	}
}

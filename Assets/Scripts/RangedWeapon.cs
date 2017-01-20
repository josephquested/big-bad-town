using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	public GameObject bulletPrefab;
	public bool shooting;
	public Sprite[] sprites;
	public float attackSpeed;
	public int weight;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Attack () {
		SetDirection(transform.parent.gameObject.GetComponent<Animates>().direction);
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
		shooting = false;
	}

	void Fire () {
		var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
	}

	void SetDirection (int direction)
	{
		spriteRenderer.sprite = sprites[direction];
		if (direction == 0) transform.localPosition = new Vector2(0, 1);
		if (direction == 1) transform.localPosition = new Vector2(0.85f, 0);
		if (direction == 2) transform.localPosition = new Vector2(0, -1);
		if (direction == 3) transform.localPosition = new Vector2(-0.85f, 0);
	}
}

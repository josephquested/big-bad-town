using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	SpriteRenderer spriteRenderer;

	public GameObject bulletPrefab;
	public Sprite[] sprites;
	public float speed;

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void ShootInDirection (int direction)
	{
		SetDirection(direction);
		spriteRenderer.enabled = true;
		StartCoroutine(ShootCoroutine(direction));
	}

	IEnumerator ShootCoroutine (int direction)
	{
		float duration = speed;
		while (duration >= 0)
		{
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}

		Fire(direction);

		duration = speed;
		while (duration >= 0)
		{
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}
		spriteRenderer.enabled = false;
	}

	void Fire (int direction) {
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

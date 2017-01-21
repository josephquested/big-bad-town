using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {
	Collider2D attackCollider;
	SpriteRenderer spriteRenderer;
	Transform parentTransform;

 	public Sprite[] sprites;
	public int damage;
	public float attackSpeed;
 	public int knockback;
	public float weight;

	void Start () {
		attackCollider = GetComponent<Collider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		parentTransform = transform.parent.transform;
	}

	void OnTriggerStay2D (Collider2D collider) {
		 if (collider.gameObject.GetComponent<Status>() != null) {
			Status status = collider.gameObject.GetComponent<Status>();
			if (!status.invulnerable) {
				status.Damage(damage);
				Knockback(collider);
			}
		}
	}

	void Knockback (Collider2D collider) {
		Vector2 diff = (collider.transform.position - parentTransform.position).normalized;
		Vector2 direction = new Vector2(Mathf.Round(diff.x), Mathf.Round(diff.y));
		collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockback);
	}

	public void Attack (bool shouldAttack) {
		if (shouldAttack) {
			SetDirection(parentTransform.gameObject.GetComponent<Animates>().direction);
			attackCollider.enabled = true;
			spriteRenderer.enabled = true;

		} else {
			attackCollider.enabled = false;
			spriteRenderer.enabled = false;
		}
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int damage;
	public Vector3 originPosition;
	public int knockback;

	public void ReceiveData (int setDamage, Transform parentTransform, int setKnockback) {
		damage = setDamage;
		originPosition = parentTransform.position;
		knockback = setKnockback;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.GetComponent<Status>() != null) {
			collider.gameObject.GetComponent<Status>().Damage(damage);
			Knockback(collider);
			Destroy(gameObject);
		}

		if (collider.gameObject.GetComponent<Explodes>() != null) {
			Explodes explodes = collider.gameObject.GetComponent<Explodes>();
			if (!explodes.explosionOnly) {
				explodes.Explode();
			}
			Destroy(gameObject);
		}

		if (collider.gameObject.layer == LayerMask.NameToLayer("Solid")) {
			Destroy(gameObject);
		}
	}

	void Knockback (Collider2D collider) {
		Vector2 diff = (collider.transform.position - originPosition).normalized;
		Vector2 direction = new Vector2(Mathf.Round(diff.x), Mathf.Round(diff.y));
		collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockback);
	}
}

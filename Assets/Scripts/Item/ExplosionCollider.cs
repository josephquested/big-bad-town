using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollider : MonoBehaviour {
	public int damage;
	public int knockback;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player" || collider.tag == "Enemy") {
			collider.gameObject.GetComponent<Status>().Damage(damage);
			Knockback(collider);
		}

		if (collider.gameObject.GetComponent<Explodes>() != null) {
			collider.gameObject.GetComponent<Explodes>().Explode();
		}
	}

	void Knockback (Collider2D collider) {
		Vector2 diff = (collider.transform.position - transform.parent.transform.position).normalized;
		Vector2 direction = new Vector2(Mathf.Round(diff.x), Mathf.Round(diff.y));
		collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockback);
	}
}

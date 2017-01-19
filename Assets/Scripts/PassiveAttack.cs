using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAttack : MonoBehaviour {
	public int damage;
	public int knockback;
	Transform parentTransform;

	void Start () {
		parentTransform = transform.parent.transform;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		 if (collider.tag == "Player") {
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
}

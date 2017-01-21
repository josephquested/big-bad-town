using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int damage;
	public Transform parentTransform;
	public int knockback;

	public void ReceiveData (int setDamage, Transform setParent, int setKnockback) {
		damage = setDamage;
		parentTransform = setParent;
		knockback = setKnockback;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player" || collider.tag == "Enemy") {
			collider.gameObject.GetComponent<Status>().Damage(damage);
			Knockback(collider);
			Destroy(gameObject);
		}

		if (collider.gameObject.GetComponent<Explodes>() != null) {
			collider.gameObject.GetComponent<Explodes>().Explode();
			Destroy(gameObject);
		}

		if (collider.gameObject.layer == LayerMask.NameToLayer("Solid")) {
			Destroy(gameObject);
		}
	}

	void Knockback (Collider2D collider) {
		Vector2 diff = (collider.transform.position - parentTransform.position).normalized;
		Vector2 direction = new Vector2(Mathf.Round(diff.x), Mathf.Round(diff.y));
		collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockback);
	}
}

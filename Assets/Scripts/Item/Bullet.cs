using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player" || collider.tag == "Enemy") {
			print("hit something!");
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public string type;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			Destroy(gameObject);
		}
	}
}

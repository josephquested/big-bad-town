using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {

	PlayerInventory inventory;
	PlayerMovement playerMovement;

	void Start () {
		inventory = transform.parent.GetComponent<PlayerInventory>();
		playerMovement = transform.parent.GetComponent<PlayerMovement>();
	}

	void Update () {
		UpdateDirection();
	}

	void UpdateDirection () {
		if (playerMovement.direction == 0) {
			transform.rotation = Quaternion.Euler(0, 0, 180);
		}
		if (playerMovement.direction == 1) {
			transform.rotation = Quaternion.Euler(0, 0, 90);
		}
		if (playerMovement.direction == 2) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		if (playerMovement.direction == 3) {
			transform.rotation = Quaternion.Euler(0, 0, 270);
		}
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (collider.tag == "LockedDoor" && Input.GetButtonDown("Attack")) {
			if (inventory.lockpicks > 0) {
				inventory.UseLockpick();
				collider.GetComponent<LockedDoor>().Unlock();
			}
		}
	}
}

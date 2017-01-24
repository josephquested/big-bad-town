using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public int lockpicks;
	public int cash;

	public void Pickup (string type, int quantity) {
		if (type == "lockpick") {
			lockpicks += quantity;
		}
		if (type == "cash") {
			cash += quantity;
		}
		if (type == "meat") {
			PlayerStatus status = GetComponent<PlayerStatus>();
			status.IncreaseMaxHealth();
		}
	}

	public void Drop (string type, int quantity) {
		if (type == "lockpick") {
			lockpicks -= quantity;
		}
		if (type == "cash") {
			cash -= quantity;
		}
	}
}

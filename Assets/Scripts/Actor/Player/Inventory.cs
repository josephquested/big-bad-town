using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private Weapon weapon;
	public int lockpicks;

	public void Pickup (string type, int quantity) {
		if (type == "lockpick") {
			lockpicks += quantity;
		}
	}

	public void Drop (string type, int quantity) {
		if (type == "lockpick") {
			lockpicks -= quantity;
		}
	}
}

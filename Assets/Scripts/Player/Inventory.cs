﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public int lockpicks;
	public int cash;
	public int bullets;

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
		if (type == "pistol") {
			RangedAttack rangedAttack = GetComponent<RangedAttack>();
			if (rangedAttack.weapon == null) {
				RangedWeapon pistol = transform.Find("Pistol").gameObject.GetComponent<RangedWeapon>();
				rangedAttack.weapon = pistol;
				bullets += 10;
			} else {
				bullets += 2;
			}
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

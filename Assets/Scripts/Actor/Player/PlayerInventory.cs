using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private Weapon weapon;
	public int lockpicks;

	public void PickupLockpick () {
		lockpicks += 1;
	}

	public void UseLockpick () {
		lockpicks -= 1;
	}
}

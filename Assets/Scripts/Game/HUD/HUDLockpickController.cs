using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDLockpickController : MonoBehaviour {
	private Inventory inventory;

	public List<Sprite> numberSprites;
	public SpriteRenderer onesSprite;

	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		UpdateLockpicks();
	}

	void Update () {
		UpdateLockpicks();
	}

	void UpdateLockpicks () {
		onesSprite.sprite = numberSprites[inventory.lockpicks];
	}
}

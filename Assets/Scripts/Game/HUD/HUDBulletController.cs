using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDBulletController : MonoBehaviour {
	private Inventory inventory;

	public List<Sprite> numberSprites;
	public SpriteRenderer tensSprite;
	public SpriteRenderer onesSprite;

	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		UpdateBullets();
	}

	void Update () {
		UpdateBullets();
	}

	void UpdateBullets () {
		int tens = Mathf.Abs(inventory.bullets);
		while (tens >= 10) {
			tens /= 10;
		}
		int ones = inventory.bullets % 10;
		tensSprite.sprite = numberSprites[tens];
		onesSprite.sprite = numberSprites[ones];
		if (inventory.bullets < 10) {
			tensSprite.sprite = numberSprites[0];
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCashController : MonoBehaviour {
	private Inventory inventory;

	public List<Sprite> numberSprites;
	public SpriteRenderer hundredsSprite;
	public SpriteRenderer tensSprite;
	public SpriteRenderer onesSprite;

	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		UpdateCash();
	}

	void Update () {
		UpdateCash();
	}

	void UpdateCash () {
		hundredsSprite.sprite = numberSprites[0];
		tensSprite.sprite = numberSprites[0];
		onesSprite.sprite = numberSprites[0];

		if (inventory.cash == 0) {
			return;
		}

		int[] cashArr = IntToIntArray(inventory.cash);
	}

	int[] IntToIntArray (int num) {
		if (num == 0)
				return new int[1] { 0 };

		List<int> digits = new List<int>();

		for (; num != 0; num /= 10)
				digits.Add(num % 10);

		int[] array = digits.ToArray();
		System.Array.Reverse(array);

		return array;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMeat : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	public Sprite[] sprites;
	public int plump;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
		UpdateSprite();
	}

	public void ChangePlump (int value) {
		if (value > 0) plump += value;
		if (value < 0) plump -= value;
		UpdateSprite();
	}

	void UpdateSprite () {
		spriteRenderer.sprite = sprites[plump];
	}
}

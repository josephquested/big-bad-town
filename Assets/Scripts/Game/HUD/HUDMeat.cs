using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMeat : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	[SerializeField] private Sprite[] sprites;
	[SerializeField] private int plump;

	void Start ()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		UpdateSprite();
	}

	public void ChangePlump (int value)
	{
		if (value > 0) plump += value;
		if (value < 0) plump -= value;
		UpdateSprite();
	}

	void UpdateSprite () {
		spriteRenderer.sprite = sprites[plump];
	}

	public int Plump {
		get { return plump; }
		set { plump = value; }
	}
}

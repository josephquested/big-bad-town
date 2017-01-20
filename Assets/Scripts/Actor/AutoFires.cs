using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFires : MonoBehaviour {
	RangedAttack rangedAttack;

	public float frequency;
	bool shooting = false;

	void Start () {
		rangedAttack = GetComponent<RangedAttack>();
	}

	void Update () {
		if (!shooting) {
			StartCoroutine(ShootCoroutine());
		}
	}

	IEnumerator ShootCoroutine ()
	{
		shooting = true;
		rangedAttack.ReceiveInput();
		float duration = frequency;

		while (duration >= 0)
		{
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}

		shooting = false;
	}
}

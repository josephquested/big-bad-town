using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedShooter : MonoBehaviour {

	public int direction;
	public float frequency;
	public float offset;

	bool shooting = false;

	public GameObject gun;

	void Update () {
		if (!shooting) {
			StartCoroutine(ShootCoroutine());
		}
	}

	IEnumerator ShootCoroutine ()
	{
		print("starting shoot coroutine!");
		float duration = frequency;
		shooting = true;
		gun.GetComponent<Gun>().ShootInDirection(direction);

		while (duration >= 0)
		{
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}

		print("finishing shoot coroutine");
		shooting = false;
	}
}

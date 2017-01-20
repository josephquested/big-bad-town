using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMeatController : MonoBehaviour {
	private Status status;

	[SerializeField] private HUDMeat[] hudMeat;

	void Start () {
		status = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
		UpdateBones();
	}

	void Update () {
		UpdateMeat();
	}

	void UpdateBones () {
		for (int i = 1; i < hudMeat.Length; i++) {
			hudMeat[i].transform.localPosition = new Vector2(hudMeat[i - 1].transform.localPosition.x + 1, 0);
		}
	}

	void UpdateMeat () {
		int health = status.health;

		for (int i = 0; i < hudMeat.Length; i++)
		{
			hudMeat[i].plump = 0;

			for (int j = 0; j < 3; j++)
			{
				if (health > 0)
				{
					hudMeat[i].plump++;
					health--;
				}
			}
		}
	}
}

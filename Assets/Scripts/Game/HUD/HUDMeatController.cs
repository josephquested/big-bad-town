using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMeatController : MonoBehaviour
{
	private PlayerStatus playerStatus;

	[SerializeField] private HUDMeat[] hudMeat;

	void Start ()
	{
		playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
		UpdateBones();
	}

	void Update ()
	{
		UpdateMeat();
	}

	void UpdateBones ()
	{
		for (int i = 1; i < hudMeat.Length; i++)
		{
			hudMeat[i].transform.localPosition = new Vector2(
				hudMeat[i - 1].transform.localPosition.x + 1,
				0
			);
		}
	}

	void UpdateMeat ()
	{
		int health = playerStatus.Health;

		for (int i = 0; i < hudMeat.Length; i++)
		{
			hudMeat[i].Plump = 0;

			for (int j = 0; j < 3; j++)
			{	
				if (health > 0)
				{
					hudMeat[i].Plump++;
					health--;
				}
			}
		}
	}
}

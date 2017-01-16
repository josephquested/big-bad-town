using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject cameraPrefab;

	void Awake ()
	{
		if (GameObject.FindGameObjectWithTag("Player") == null)
		{
			Instantiate(playerPrefab, playerPrefab.transform.position, Quaternion.identity);
		}

		if (GameObject.FindGameObjectWithTag("MainCamera") == null)
		{
			Instantiate(cameraPrefab, transform.position, Quaternion.identity);
		}
	}
}

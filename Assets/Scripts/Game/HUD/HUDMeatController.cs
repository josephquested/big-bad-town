using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMeatController : MonoBehaviour {
	private Status status;

	public GameObject hudMeatPrefab;
	public List<HUDMeat> hudMeat;

	void Start () {
		status = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
		UpdateBones();
	}

	void Update () {
		UpdateMeat();
	}

	public void AddMeat () {
		var newMeat = Instantiate(hudMeatPrefab, transform.position, transform.rotation);
		hudMeat.Add(newMeat.GetComponent<HUDMeat>());
		newMeat.transform.parent = transform;
		newMeat.transform.position = new Vector2(transform.position.x + (0.5f * hudMeat.Count + 0.5f), transform.position.y);
	}

	void UpdateBones () {
		for (int i = 1; i < hudMeat.Count; i++) {
			hudMeat[i].transform.localPosition = new Vector2(hudMeat[i - 1].transform.localPosition.x + 0.5f, 0);
		}
	}

	void UpdateMeat () {
		int health = status.health;

		for (int i = 0; i < hudMeat.Count; i++)
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

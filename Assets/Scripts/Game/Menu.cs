using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

	void Update ()
	{
		if (Input.GetButtonDown("Start") || Input.GetButtonDown("Attack") || Input.GetButtonDown("Shoot"))
		{
			StartCoroutine(StartRoutine());
		}
	}

	IEnumerator StartRoutine ()
	{
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene("house-mom");
	}
}

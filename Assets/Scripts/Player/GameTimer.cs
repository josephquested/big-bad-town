using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {
	public int gameTime = 0;
	public bool running = true;

	void Start ()
	{
		StartCoroutine(StartTimer());
	}

	IEnumerator StartTimer ()
	{
		while (running)
		{
			yield return new WaitForSeconds(1f);
			gameTime += 1;
		}
	}

	public void StopTimer ()
	{
		running = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
	private ScreenController screenController;
	public bool screenActive = false;

	void Start ()
	{
		screenController = transform.parent.GetComponent<ScreenController>();
	}

	void Update ()
	{
		screenController.SetGameScreenState(this);
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			screenController.ActiveGameScreen = this;
		}
	}

	public void ResetGameScreen ()
	{
		if (!screenActive) return;
		screenActive = false;
		BroadcastMessage("Reset", SendMessageOptions.DontRequireReceiver);
	}

	public void ActivateGameScreen ()
	{
		if (screenActive) return;
		screenActive = true;
		BroadcastMessage("Activate", SendMessageOptions.DontRequireReceiver);
	}
}

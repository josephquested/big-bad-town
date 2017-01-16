using UnityEngine;
﻿using System.Collections;

public class ScreenController : MonoBehaviour
{
	private CameraController cameraController;
	private GameScreen activeGameScreen;

	void Start ()
	{
		cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
	}

	public void SetGameScreenState (GameScreen screen)
	{
		if (screen == activeGameScreen && !cameraController.Transitioning)
		{
			screen.ActivateGameScreen();
		}
		else if (screen != activeGameScreen && !cameraController.Transitioning)
		{
			screen.ResetGameScreen();
		}
	}

	public GameScreen ActiveGameScreen
	{
		get { return activeGameScreen; }
		set
		{
			activeGameScreen = value;
			cameraController.SetGameScreen(activeGameScreen.gameObject.transform);
		}
	}
}

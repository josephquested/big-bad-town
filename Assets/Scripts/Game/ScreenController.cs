using UnityEngine;
﻿using System.Collections;

public class ScreenController : MonoBehaviour
{
	public CameraController cameraController;
	private GameScreen activeGameScreen;

	void Start ()
	{
		cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
	}

	public void SetGameScreenState (GameScreen screen)
	{
		print(screen);
		print(cameraController.Transitioning);

		if (screen == activeGameScreen && !cameraController.Transitioning)
		{
			print("should activate game screen");
			screen.ActivateGameScreen();
		}
		else if (screen != activeGameScreen && !cameraController.Transitioning)
		{
			print("should reset game screen");
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

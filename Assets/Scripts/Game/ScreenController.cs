using UnityEngine;
﻿using System.Collections;

public class ScreenController : MonoBehaviour {
	CameraController cameraController;

	public GameScreen activeGameScreen;

	void Start () {
		cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
	}

	public void SetGameScreenState (GameScreen screen) {
		if (screen == activeGameScreen && !cameraController.transitioning) {
			screen.ActivateGameScreen();
		} else if (screen != activeGameScreen && !cameraController.transitioning) {
			screen.ResetGameScreen();
		}
	}

	public void SetGameScreen (GameScreen newScreen) {
		activeGameScreen = newScreen;
		cameraController.SetGameScreen(activeGameScreen.gameObject.transform);
	}
}

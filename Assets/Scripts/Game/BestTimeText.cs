using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeText : MonoBehaviour {
	public Text timeText;

	void Start ()
	{
		if (PlayerPrefs.GetInt("winTime") == 0)
		{
			print("no win time");
			timeText.text = "NULL";
		}
		else
		{
			int gameTime = PlayerPrefs.GetInt("winTime");
			int minutes = (gameTime % 3600) / 60;
			int seconds = (gameTime % 3600 ) % 60;
			timeText.text = minutes.ToString() + ":" + seconds.ToString();
		}
	}
}

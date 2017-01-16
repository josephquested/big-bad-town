using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform screen;
	private bool transitioning;
  private float lerpTime;

	public float speed = 1.0F;

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
		Screen.SetResolution(800, 600, false);
	}

	public void Start ()
	{
		screen = transform;
		lerpTime = Time.time;
	}

	public void SetGameScreen (Transform newGameScreen)
	{
		SetTransitioning(newGameScreen);
		if (screen == newGameScreen) return;
		screen = newGameScreen;
		lerpTime = Time.time;
	}

	void SetTransitioning (Transform newGameScreen)
	{
		transitioning = !(
			transform.position.x == newGameScreen.position.x
			&& transform.position.y == newGameScreen.position.y
		);
	}

	void Update ()
	{
		if (screen == null) return;
		Vector3 target = new Vector3(screen.position.x, screen.position.y, -10f);
    float distanceLerped = (Time.time - lerpTime) * speed;
		float journeyLength = Vector3.Distance(transform.position, target);
		float fracJourney = distanceLerped / journeyLength;
		if (float.IsNaN(fracJourney)) return;
    transform.position = Vector3.Lerp(transform.position, target, fracJourney);
  }

	public bool Transitioning {
		get { return transitioning; }
	}
}

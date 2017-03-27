using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.05f;

	private int drawDepth = -1000;
	private float alpha = 0.0f;
	private int fadeDirection = 0;

	void OnGUI () {
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	void Start ()
	{
		StartCoroutine(CreditRoutine());
	}

	IEnumerator CreditRoutine ()
	{
		yield return new WaitForSeconds(19f);
		StartCoroutine(FadeOut());
	}

	public float BeginFade (int direction) {
		fadeDirection = direction;
		return (fadeSpeed);
	}

	IEnumerator FadeOut ()
	{
		AudioSource BGM = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
		while (BGM.volume > 0)
		{
			BGM.volume -= 0.001f;
			BeginFade(1);
			yield return new WaitForSeconds(0.01f);
		}
		Destroy(GameObject.FindWithTag("Player"));
		Destroy(GameObject.FindWithTag("MainCamera"));
		SceneManager.LoadScene("menu");
	}
}

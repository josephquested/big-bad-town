using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
	[SerializeField] private string scene;
	[SerializeField] private Vector2 spawnLocation;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			StartCoroutine(SceneTransition(collider));
		}
	}

	IEnumerator SceneTransition (Collider2D collider)
	{
		float fadeTime = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(scene);
		collider.transform.position = spawnLocation;
		GameObject.FindGameObjectWithTag("MainCamera").transform.position = spawnLocation;
	}
}

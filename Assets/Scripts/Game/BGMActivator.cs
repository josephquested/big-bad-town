using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMActivator : MonoBehaviour {

	void Start () {
		GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
	}
}

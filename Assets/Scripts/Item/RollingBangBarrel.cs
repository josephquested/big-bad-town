using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBangBarrel : MonoBehaviour {
	Animator animator;

	void Awake () {
		animator = GetComponent<Animator>();
		animator.SetBool("rolling", true);
	}
}

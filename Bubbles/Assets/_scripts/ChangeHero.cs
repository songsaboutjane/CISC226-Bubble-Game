﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHero : MonoBehaviour {
	public Sprite sprite1, sprite2;
	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		bool facingLeft = false;
		var charPosition = Camera.main.WorldToScreenPoint(transform.position);
		var direction = Input.mousePosition - charPosition;
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Debug.Log (angle);
		if (angle > 90 || angle <= -90) {
			facingLeft = true;
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else {
			facingLeft = false;
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}

		if (Input.GetKey (KeyCode.Space)) {
			sr.sprite = sprite2;
			if (facingLeft == true) {
				transform.localRotation = Quaternion.Euler (0, 0, 0);
			}
		}

		else {
			sr.sprite = sprite1;
		}
	}
}
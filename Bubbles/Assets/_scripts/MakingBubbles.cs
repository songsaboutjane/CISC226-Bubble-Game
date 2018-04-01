﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingBubbles : MonoBehaviour {
	public int bubbleLimit;
	public static int bubbleCount=0;
	public Rigidbody2D bubblePrefab;
	public float radius = 1.04f;
	public static Collider pickup;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CastRay();
		}
	}

	void CastRay() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		if (hit) {
			if (hit.collider.gameObject.name == "hero" || hit.collider.gameObject.name == "blockpickup" || hit.collider.gameObject.name == "background1") {
				if (bubbleCount <= bubbleLimit) {
					bubbleCount++;
					Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Instantiate (bubblePrefab, new Vector3 (position.x, position.y, 0), Quaternion.identity);
				}
			}
		} /*else {
			if (bubbleCount <= bubbleLimit) {
				bubbleCount++;
				Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Instantiate (bubblePrefab, new Vector3 (position.x, position.y, 0), Quaternion.identity);
			}
		}*/
	}
}
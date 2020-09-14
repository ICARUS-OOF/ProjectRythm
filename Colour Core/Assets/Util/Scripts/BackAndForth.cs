using UnityEngine;
using System.Collections;

public class BackAndForth : MonoBehaviour {

	public float delta = 1.5f;
	public float speed = 2.0f; 
	private Vector3 startPos;
	public bool MoveMode; 

	void Start () {
		startPos = transform.position;
	}

	void Update () {

		if (MoveMode) {
			Vector3 v = startPos;
			v.y += delta * Mathf.Sin (Time.time * speed);
			transform.position = v;
		} else {
			Vector3 v = startPos;
			v.x += delta * Mathf.Sin (Time.time * speed);
			transform.position = v;
		}
	}
}
using UnityEngine;
using System.Collections;

public class Mouselook2d : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		transform.LookAt (new Vector3(worldPoint.x, worldPoint.y, 0.0f), Vector3.forward);
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class KeyboardMovement : MonoBehaviour {

	private Rigidbody2D target;

	// Use this for initialization
	void Start () {
		target = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (input.sqrMagnitude > 1.0f) {
			input.Normalize();
		}
		target.AddForce (input * 5000);
	}
}

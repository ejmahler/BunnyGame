using UnityEngine;
using System.Collections;

public class BunnyMovement : MonoBehaviour {
	private Vector2 destination;
	[SerializeField]
	private float range=15f;
	private Rigidbody2D _rigidbody;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		StartCoroutine (SetDestination ());
	}
	IEnumerator SetDestination()
	{
		while (true) {

			while (true) {
				Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
				destination = new Vector2 (Random.Range (-range, range), Random.Range (-range, range))+pos;
				float distance = Vector2.Distance (destination, transform.position);

				if (distance > 3f) {
					//print("got a destination");


//					Vector2 origin = pos + (destination - pos).normalized*2;
//					RaycastHit2D hit= Physics2D.Raycast(transform.position,destination,distance);
//
//					if(hit.transform!=transform)
//					{
//						print ("hit"+hit.transform);
//					}
//
//					if(hit.collider==null){
//					break;
//					}
					break;

				}
			}
			yield return new WaitForSeconds (2f);
		}
	}
	private void MoveToDestination()
	{
		if (Vector2.Distance (destination, transform.position) > 1f) {
			Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
			Vector2 tempDestination = pos + (destination - pos).normalized*Time.deltaTime;
			_rigidbody.MovePosition (tempDestination);
		} else {
			_rigidbody.MovePosition (destination);
		}
	}
	// Update is called once per frame
	void Update () {
		MoveToDestination ();
	}
}

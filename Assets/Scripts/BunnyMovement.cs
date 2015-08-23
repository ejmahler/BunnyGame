using UnityEngine;
using System.Collections;

public class BunnyMovement : MonoBehaviour {
	private Vector2 destination;
	[SerializeField]
	private float range=15f;
	[SerializeField]
	private float timeInterval=2f;
	private Rigidbody2D _rigidbody;
	private float closestEnemyDistance=3f;
	Vector2 targetPos;
	GameObject targetEnemy;
	bool isEscaping;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		destination = transform.position;
		StartCoroutine (SetDestination ());
	}
	IEnumerator SetDestination()
	{
		while (true) {
			SetRandomDestination();

			yield return new WaitForSeconds (timeInterval);
		}
	}
	private void SetRandomDestination(){
		while (true) {
			Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
			destination = new Vector2 (Random.Range (-range, range), Random.Range (-range, range))+pos;
			float distance = Vector2.Distance (destination, transform.position);
			
			if (distance > 3f) {
				break;
			}
		}
	}
	private void MoveToDestination()
	{
		float multiple;
		if (isEscaping) {
			multiple = 3f;
		} else {
			multiple=1f;
		}

		if (Vector2.Distance (destination, transform.position) > 1f) {
			Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
			Vector2 tempDestination = pos + (destination - pos).normalized*Time.deltaTime*multiple;
			_rigidbody.MovePosition (tempDestination);
		} else {
			//_rigidbody.MovePosition (destination);
		}
	}
	private void SetEscapingDestination()
	{
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
		destination = pos + (pos - targetPos).normalized;
	}
	// Update is called once per frame
	void Update () {
		if (isEscaping) {
			SetEscapingDestination ();
		} 
		MoveToDestination ();
		if (targetEnemy != null) {
			if (Vector2.Distance (transform.position, targetEnemy.transform.position) > 3f) {
				isEscaping = false;
				targetEnemy = null;
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other != null && other.gameObject.tag == "Enemy") {
			Vector2 pos= new Vector2(other.transform.position.x,other.transform.position.y);
			isEscaping = true;
			float distance = Vector2.Distance (transform.position, pos);
			if (distance < closestEnemyDistance) {
				targetEnemy=other.gameObject;

			}
			if(targetEnemy==other.gameObject)
			{
				closestEnemyDistance = distance;
				targetPos = pos;
			}
		} 
	}
}

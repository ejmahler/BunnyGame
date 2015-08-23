using UnityEngine;
using System.Collections;

public class CopyController : MonoBehaviour {

	private Rigidbody2D target;
	private Vector3 destination;

	[SerializeField]
	private float searchSpeed = 2;

	[SerializeField]
	private float chaseSpeed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			//set the destination to the target's last known position so that if we lose LOS we can still try to chase
			destination = target.transform.position;

			Vector3 directionToDest = (destination - transform.position).normalized;
			GetComponent<Rigidbody2D>().MovePosition(transform.position + directionToDest * Time.fixedDeltaTime * chaseSpeed);

			//check for LOS to target
			if(!hasLOStoObject(target.GetComponent<Collider2D>())) {
				target = null;
			}

		} else if ((transform.position - destination).sqrMagnitude < 0.1f) {
			//goto destination
			Vector3 directionToDest = (destination - transform.position).normalized;
			GetComponent<Rigidbody2D>().MovePosition(transform.position + directionToDest * Time.fixedDeltaTime * searchSpeed);
		} else {
			//pick a new destination
			ChooseRandomDestination();
		}

		//look at destination
		transform.LookAt (new Vector3(destination.x, destination.y, transform.position.z), Vector3.forward);
	}

	private void ChooseRandomDestination() {
		Vector3 possibleDirection = Random.insideUnitCircle * 5f;
		Vector3 normalizedDirection = possibleDirection.normalized;
		Vector3 possibleDestination = transform.position + possibleDirection;

		float copyRadius = GetComponent<CircleCollider2D>().radius;

		//verify that we have LOS to this destination
		RaycastHit2D hit = Physics2D.Raycast(transform.position + normalizedDirection * (copyRadius + .01f), normalizedDirection, possibleDirection.magnitude);
		if(hit.collider == null)
		{
			destination = possibleDestination;
		}
	}

	void OnTriggerStay2D(Collider2D other) {

		//check if other has a rigidbody
		if (other.GetComponent<Rigidbody2D> () == null)
			return;

		//check if other is withn our sight range
		Vector3 directionToOther = (other.transform.position - transform.position);
		if (Vector3.Angle (this.transform.forward, directionToOther) > 45)
			return;

		//check if we have LOS to this target
		if (!hasLOStoObject (other)) {
			return;
		}

		//we want this as a target!
		if (target == null) {
			target = other.GetComponent<Rigidbody2D> ();
		} else {
			//see if "other" is a bunny, if so, prioritize it over non bunnies
			if(other.gameObject.tag == "Bunny" && target.gameObject.tag != "Bunny") {
				target = other.GetComponent<Rigidbody2D>();
			} else {
				//see if "other" is closer
				if(Vector3.Distance(transform.position, other.transform.position) < Vector3.Distance(transform.position, target.transform.position)) {
					target = other.GetComponent<Rigidbody2D>();
				}
			}
		}
	}

	private bool hasLOStoObject(Collider2D other) {
		float copyRadius = GetComponent<CircleCollider2D>().radius;
		float distanceToOther = Vector3.Distance (this.transform.position, other.transform.position);
		Vector3 directionToOther = (other.transform.position - transform.position).normalized;

		RaycastHit2D hit = Physics2D.Raycast(transform.position + directionToOther * (copyRadius + .1f), directionToOther, distanceToOther);
		if (hit.collider != null && hit.collider != other) {
		}
		return hit.collider != null && hit.collider == other;
	}
}

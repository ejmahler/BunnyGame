using UnityEngine;
using System.Collections;

public class SpawnCopy : MonoBehaviour {

	[SerializeField]
	private GameObject copyPrefab;

	[SerializeField]
	private float duration;

	private float timeRemaining;

	// Use this for initialization
	void Start () {
		timeRemaining = duration;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeRemaining -= Time.fixedDeltaTime;

		if (timeRemaining <= 0f) {
			Instantiate(copyPrefab, this.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class SpawnCopyPlaceholder : MonoBehaviour {

	[SerializeField]
	private GameObject placeholderPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (placeholderPrefab, this.transform.position, Quaternion.identity);
		}
	}
}

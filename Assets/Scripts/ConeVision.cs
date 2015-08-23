using UnityEngine;
using System.Collections;

public class ConeVision : MonoBehaviour {
	private float radius=1f;

	// Use this for initialization
	void Start () {
	
	}
	void CheckForObjectsWithinRange()
	{
		foreach (GameObject b in GameMaster.g.Bunnies)
		{
			if(Vector2.Distance(b.transform.position,transform.position)<radius)
			{
				GameMaster.g.RemoveEntity(b);
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}

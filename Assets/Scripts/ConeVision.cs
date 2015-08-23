using UnityEngine;
using System.Collections;

public class ConeVision : MonoBehaviour {
	[SerializeField]
	private float radius=1f;

	// Use this for initialization
	void Start () {
	
	}
	void CheckForObjectsWithinRange()
	{
		foreach (GameObject b in GameMaster.g.Bunnies)
		{
			//print("distance"+Vector2.Distance(b.transform.position,transform.position));
			if(Vector2.Distance(b.transform.position,transform.position)<radius)
			{
				GameMaster.g.RemoveEntity(b);
				print("Remove");
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
		CheckForObjectsWithinRange ();
	}
}

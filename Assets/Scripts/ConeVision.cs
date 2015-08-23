using UnityEngine;
using System.Collections;

public class ConeVision : MonoBehaviour {
	[SerializeField]
	private float radius=1f;
	[SerializeField]
	private float angle=30f;

	[SerializeField]
	private Sprite _coneSprite;

	private Light forwardLight;

	// Use this for initialization
	void Start () {
		var light = transform.Find ("ForwardLight");
		if (light != null) {
			forwardLight = light.GetComponent<Light>();
		}
	}
	void CheckForObjectsWithinRange()
	{
		foreach (GameObject b in GameMaster.g.Bunnies)
		{
			//print("distance"+Vector2.Distance(b.transform.position,transform.position));
			if(Vector2.Distance(b.transform.position,transform.position)<radius  && Vector2.Angle((b.transform.position-transform.position),transform.forward)<angle/2)
			{
				GameMaster.g.RemoveEntity(b);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		CheckForObjectsWithinRange ();

		if (forwardLight != null) {
			forwardLight.spotAngle = angle;
		}
	}
}





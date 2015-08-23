using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameMaster : MonoBehaviour {
	[HideInInspector]
	public List <GameObject> Bunnies = new List<GameObject>();
	List <GameObject> BunniesToRemove = new List<GameObject>();

	public static GameMaster g;
	// Use this for initialization
	void Start () {
		if (g == null)
		{
			g = this;
		}
		else
		{
			Destroy(this);
		}
		FindAllBunnies ();
	}
	private void FindAllBunnies()
	{
		Bunnies=GameObject.FindGameObjectsWithTag("Bunny").ToList();
		print (Bunnies.Count);
	}


	public void RemoveEntity(GameObject b)
	{
		BunniesToRemove.Add (b);

	}
	IEnumerator RemoveEntitiesFromList()
	{
		yield return new WaitForEndOfFrame();
		foreach(GameObject b in BunniesToRemove)
		{
			if(b!=null)
			{
				Bunnies.Remove (b);
				GameObject.Destroy (b);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine (RemoveEntitiesFromList ());
	}
}

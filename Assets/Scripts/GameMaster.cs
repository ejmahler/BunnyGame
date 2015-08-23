using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public enum GameState
{
	MainMenu,
	Starting,
	InGame,
	Restart
}

public class GameMaster : MonoBehaviour {
	[HideInInspector]
	public List <GameObject> Bunnies = new List<GameObject>();
	List <GameObject> BunniesToRemove = new List<GameObject>();

	public GameState gameState;

	[SerializeField]
	private GameObject gameMenuUI;
	[SerializeField]
	private GameObject inGameUI;
	[SerializeField]
	private GameObject restartUI;

	[SerializeField]
	Text BunniesCount;
	[SerializeField]
	Text Timer;

	[SerializeField]
	float gameTime=60f;

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
		gameState = GameState.MainMenu;
		gameMenuUI.SetActive (true);
		inGameUI.SetActive (false);
		restartUI.SetActive (false);

	}
	private void FindAllBunnies()
	{
		Bunnies=GameObject.FindGameObjectsWithTag("Bunny").ToList();
	}

	public void StartGame()
	{
		gameState = GameState.Starting;
		FindAllBunnies ();
		gameMenuUI.SetActive (false);
		inGameUI.SetActive (false);
		restartUI.SetActive (false);

		StartCoroutine (Countdown ());
	}
	public IEnumerator Countdown() {
		yield return new WaitForSeconds (3);
		GamePlayBegin ();
	}
	private void GamePlayBegin()
	{
		gameState = GameState.InGame;
		inGameUI.SetActive (true);
		StartCoroutine (InGameCountDown());
	}
	IEnumerator InGameCountDown(){
		float timer = gameTime;
		while (timer > 0f) {
			timer -= Time.deltaTime;
			Timer.text=((int)timer).ToString();
			yield return null;
		}
	}

	public void EndGame()
	{
		gameState = GameState.Restart;
		gameMenuUI.SetActive (false);
		inGameUI.SetActive (false);
		restartUI.SetActive (true);

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
		if (gameState == GameState.InGame) {
			BunniesCount.text=Bunnies.Count.ToString();

		}

	}
}

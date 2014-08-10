using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private Player[] players;
	private int currentPlayerIndex;
	private int diceResult;
	private int turnNumber;
	private BaseField[] fields;
	// Use this for initialization
	void Start () {
		currentPlayerIndex = 0;
		turnNumber = 0;
		players = (Player[])FindObjectsOfType(typeof(Player));
		fields = (BaseField[])FindObjectsOfType(typeof(BaseField));

		StartCoroutine (GameLoop());
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator GameLoop(){
		while(turnNumber < 60){
			throwDice();
			yield return StartCoroutine( movePawn() );
			playField();
			switchPlayer();
			if (currentPlayerIndex >= players.Length){
				EndTurn();
			}
		}
	}

	void throwDice ()
	{
		diceResult = Random.Range (1, 7);
	}

	IEnumerator movePawn ()
	{
		PawnMover currentPawnMover = players[currentPlayerIndex].GetComponent<PawnMover>();
//		print(players.Length);
		print ("Player " + players[currentPlayerIndex].name + " moves " + diceResult.ToString() + " fields");
		yield return StartCoroutine(currentPawnMover.Jump(fields[diceResult].position));
	}

	void playField ()
	{
//		throw new System.NotImplementedException ();
	}

	void switchPlayer ()
	{
		currentPlayerIndex++;
	}

	void EndTurn ()
	{
		currentPlayerIndex = 0;
		turnNumber++;
	}
}

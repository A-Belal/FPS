/*
Author:Abobaker Belal - 300748727
File: GameController.cs
Creation date:Nov 13 


*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	//public instance variables
	public Text scoreLabel;
	public Text livesLabel;
	//private instance variables
	private int _scoreValue;
	private int _livesValue;
	//public properties
	public int Score {
		get {
			return this._scoreValue;
		}
		set {
			this._scoreValue = value;
			this._updateScoreBoard ();

		}
	}
	//method for adding score
	public void AddScore (int value)
	{
		this._scoreValue += value;
	}
	public int Lives {
		get {
			return this._livesValue;
		}
		set {
			this._livesValue = value;
			this._updateScoreBoard ();

		}
	}
	//method for adding lives
	public void AddLives (int value)
	{
		this._livesValue += value;
	}
	//method for subtracting lives
	public void SubtractLives (int value)
	{
		this._livesValue -= value;
	}

	// Use this for initialization
	void Start () {
		this._livesValue = 0;
		this._scoreValue = 5;
		this._updateScoreBoard ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//private methods
	private void _updateScoreBoard()
	{
		this.scoreLabel.text = "Score: " + this._scoreValue;
		this.livesLabel.text = "Lives: " + this._livesValue;
	}
}

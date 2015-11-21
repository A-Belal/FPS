/*
Author:Abobaker Belal - 300748727
File: CapsuleController.cs
Creation date:Nov 20 

*/

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed
{
	//min and max speed for asteroid right now set to 2 and 10
	public float minSpeed, maxSpeed;
}
[System.Serializable]
public class Drift
{
	//min and max drift speed
	public float minDrift, maxDrift;
}
[System.Serializable]
public class Boundary
{
	//setting boundary for enemy asteroids
	public float xMin, xMax, zMin, zMax;
}



public class CapsuleController : MonoBehaviour {


	private float _currentSpeed;
	private float _currentDrift;

	public Speed speed;
	public Drift drift;
	public Boundary boundary;
	//public instance variables
	// Use this for initialization
	void Start () {
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 currentPosition = new Vector3 (0, 0, 0);
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x += this._currentDrift;
		currentPosition.z += this._currentDrift;
	}
	 private void _Reset()
		    {
		this._currentDrift = Random.Range (drift.minDrift, drift.maxDrift);
		this._currentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
			//position of game
			Vector3 resetPosition = new Vector3(Random.Range(boundary.xMin, boundary.xMax),0, Random.Range(boundary.zMax, boundary.zMin));
			gameObject.GetComponent<Transform>().position = resetPosition;
		}
}

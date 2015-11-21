/*
Author:Abobaker Belal - 300748727
File: PlayerMotor.cs
Creation date:Nov 10 
*/

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
	//serialized fields
	[SerializeField]
	private Camera cam;
	[SerializeField]
	private float cameraRotationLimit = 85f;
	//private instance variables
	private Vector3 velocity = Vector3.zero;
	private Rigidbody rb;
	private Vector3 rotation = Vector3.zero;
	private float cameraRotationX = 0f;
	private float currentCameraRotationX = 0f;
	private Vector3 thrusterForce = Vector3.zero;
	

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}
	//movement vector
	public void Move (Vector3 _velocity)
	{
		velocity = _velocity;
	}
	//rotation vector
	public void Rotate (Vector3 _rotation)
	{
		rotation = _rotation;
	}

	//rotation vector for camera
	public void RotateCamera (float _cameraRotationX)
	{
		cameraRotationX = _cameraRotationX;
	}
	//get force for thruster (jump)
	public void ApplyThruster(Vector3 _thrusterForce)
	{
		thrusterForce = _thrusterForce;
	}
	//run every iterations
	void FixedUpdate ()
	{
		PerformMovement ();
		PerformRotation ();
	}

	//perform movement method
	void PerformMovement ()
	{
		if (velocity != Vector3.zero) {
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}

		if (thrusterForce != Vector3.zero) {
			rb.AddForce (thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
		}
	}
	//perform rotation method
	void PerformRotation()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler(rotation));

		if (cam != null) {
			//set camera rotation
			currentCameraRotationX -= cameraRotationX; 
			currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
			//apply camera rotation
			cam.transform.localEulerAngles = new Vector3 (currentCameraRotationX, 0f, 0f);
		}
	}
}

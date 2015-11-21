/*
Author:Abobaker Belal - 300748727
File: PlayerController.cs
Creation date:Nov 15
*/

using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
	//serialized fields
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;

	[SerializeField]
	private float thrusterForce = 1000f;

	[Header("Joint Options")]
	[SerializeField]
	private JointDriveMode jointMode = JointDriveMode.Position;
	[SerializeField]
	private float jointSpring = 20f;
	[SerializeField]
	private float jointMaxForce = 40f;

	private PlayerMotor motor;
	private ConfigurableJoint joint;

	void Start()
	{
		motor = GetComponent<PlayerMotor> ();
		joint = GetComponent<ConfigurableJoint> ();
		SetJointSettings (jointSpring);
	}

	void Update()
	{
		//calculate movement velocity
		float _xMov = Input.GetAxisRaw ("Horizontal");
		float _zMov = Input.GetAxisRaw ("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _moveVertical = transform.forward * _zMov;
		//combining both movement and multiplying by speed
		//final movement vector
		Vector3 _Velocity = (_movHorizontal + _moveVertical).normalized * speed;

		//apply movement
		motor.Move (_Velocity);

		//calculate rotation of player (Turning)
		float _yRot = Input.GetAxisRaw ("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		//apply rotation on player
		motor.Rotate (_rotation);

		//calculate camera rotation of (Turning)
		float _xRot = Input.GetAxisRaw ("Mouse Y");
		
		float _cameraRotationX = _xRot * lookSensitivity;
		
		//apply rotation on camera
		motor.RotateCamera (_cameraRotationX);
		//calculate thruster force based on input (jump)s
		Vector3 _thrusterForce = Vector3.zero;
		if (Input.GetButton ("Jump")) {
			_thrusterForce = Vector3.up * thrusterForce;
			SetJointSettings (0f);
		} else {
			SetJointSettings (jointSpring);
		}
		//apply thrust force
		motor.ApplyThruster (_thrusterForce);
	}

	private void SetJointSettings(float _jointSpring)
	{
		joint.yDrive = new JointDrive{
			mode = jointMode,  
			positionSpring = _jointSpring, 
			maximumForce = jointMaxForce
		};
	}
}

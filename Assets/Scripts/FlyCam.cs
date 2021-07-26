using UnityEngine;
 
public class FlyCam : MonoBehaviour
{
 
	/*
	EXTENDED FLYCAM
		Desi Quintans (CowfaceGames.com), 17 August 2012.
		Based on FlyThrough.js by Slin (http://wiki.unity3d.com/index.php/FlyThrough), 17 May 2011.
 
	LICENSE
		Free as in speech, and free as in beer.
 
	FEATURES
		WASD/Arrows:    Movement
		          Q:    Climb
		          E:    Drop
                      Shift:    Move faster
                    Control:    Move slower
                        End:    Toggle cursor locking to screen (you can also press Ctrl+P to toggle play mode on and off).
	*/
 
	public float cameraSensitivity = 90;
	public float climbSpeed = 4;
	public float normalMoveSpeed = 10;
	public float slowMoveFactor = 0.25f;
	public float fastMoveFactor = 3;
 
	void Start ()
	{
        Cursor.lockState = CursorLockMode.None;
	}

	void Update ()
	{
		Transform _transform = Camera.main.gameObject.transform;
		if (Cursor.lockState == CursorLockMode.Locked) {
				float pitch = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.smoothDeltaTime;
        float yaw = Input.GetAxis("Mouse X") * cameraSensitivity * Time.smoothDeltaTime;
				_transform.Rotate(-pitch, 0, 0, Space.Self);
        _transform.Rotate(0, yaw, 0, Space.World);
		}

		float moveSpeed = normalMoveSpeed;
	 	if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
	 	{
			 moveSpeed = moveSpeed * fastMoveFactor;
	 	}
	 	else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
	 	{
			 moveSpeed = moveSpeed * slowMoveFactor;
	 	}

		_transform.position += _transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
		_transform.position += _transform.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
 
 
		if (Input.GetKey(KeyCode.Q)) {_transform.position += _transform.up * climbSpeed * Time.deltaTime;}
		if (Input.GetKey(KeyCode.E)) {_transform.position -= _transform.up * climbSpeed * Time.deltaTime;}
 
		if (Input.GetKeyDown(KeyCode.Z))
		{
			Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
		}
	}
}
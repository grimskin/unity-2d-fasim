using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour {
	[Range((float)1, (float)10.0)]
	public float moveSpeedX = 4f;

	[Range((float)1, (float)10.0)]
	public float moveSpeedY = 4f;

	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(moveSpeedX * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-moveSpeedX * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-moveSpeedY * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,moveSpeedY * Time.deltaTime,0));
		}		
	}
}

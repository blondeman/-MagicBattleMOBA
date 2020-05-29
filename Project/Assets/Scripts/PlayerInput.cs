using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public Move move;
	public new Camera camera;
	Vector2 direction = new Vector2();

	void Update()
    {
		float angle = camera.transform.eulerAngles.y;
		direction.x = Input.GetAxisRaw("Horizontal") * Mathf.Sin(angle) - Input.GetAxisRaw("Vertical") * Mathf.Cos(angle);
		direction.y = Input.GetAxisRaw("Horizontal") * Mathf.Sin(angle) + Input.GetAxisRaw("Vertical") * Mathf.Cos(angle);		
		move.SetDirection(direction);

		if (Input.GetButtonDown("Jump")) move.Jump();
	}
}

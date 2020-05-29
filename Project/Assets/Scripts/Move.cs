using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public new Rigidbody rigidbody;
	public float groundForce;
	public float airForce;
	public float jumpForce;
	public float terminalVelocity;
	public LayerMask groundMask;

	Vector2 direction;
	public void SetDirection(Vector2 dir)
	{
		print(dir);
		direction = dir.normalized;
	}

	public void Jump()
	{
		if (IsGrounded())
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0.1f, rigidbody.velocity.z);
			rigidbody.AddForce(Vector3.up * jumpForce);
		}
	}

	private void FixedUpdate()
	{
		if (IsGrounded())
		{
			rigidbody.AddForce(new Vector3(direction.x, 0, direction.y) * groundForce);
		}
		else
		{
			rigidbody.AddForce(new Vector3(direction.x, 0, direction.y) * airForce);
		}

		Vector2 currentVelocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z);
		if (currentVelocity.magnitude > terminalVelocity)
		{
			currentVelocity = currentVelocity.normalized * terminalVelocity;
			rigidbody.velocity = new Vector3(currentVelocity.x, rigidbody.velocity.y, currentVelocity.y);
		}
	}

	bool IsGrounded()
	{
		Debug.DrawRay(transform.position, Vector3.down * .6f,Color.red);
		return Physics.SphereCast(new Ray(transform.position, Vector3.down), .4f, .2f, groundMask) && rigidbody.velocity.y <= 0;		
	}
}

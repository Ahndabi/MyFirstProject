using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
	[SerializeField] float moveSpeed;
	Rigidbody rb;
	Vector3 dir;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Move();
	}

	void OnMove(InputValue value)
	{
		dir.x = value.Get<Vector2>().x;
		dir.z = value.Get<Vector2>().y;
	}

	void Move()
	{
		rb.AddForce(dir * moveSpeed, ForceMode.Force);
	}
}

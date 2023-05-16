using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyMove : MonoBehaviour
{
	Rigidbody rb;
	Vector3 dir;
	[SerializeField] float Speed;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Move();
	}

	public void OnMove(InputValue value)
	{
		dir.x = value.Get<Vector2>().x;
		dir.z = value.Get<Vector2>().y;
	}

	void Move()
	{
		rb.AddForce(dir * Speed * Time.deltaTime, ForceMode.Force);
	}
}

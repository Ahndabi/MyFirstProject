using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankTransform : MonoBehaviour
{
	// Transform 이동 탱크 구현
	// Transform 컴포넌트를 가지고 Translate와 Rotate로 이동, 회전하는 탱크 구현

	Rigidbody rb;
	Vector3 movedir;
	[SerializeField]
	float speed;
	[SerializeField]
	float rotatespeed;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		// Move();
		// Rotate();
	}

	void Rotate()
	{
		transform.Rotate(Vector3.up, Time.deltaTime * rotatespeed * movedir.x, Space.Self);
	}

	void Move()
	{
		transform.Translate(Vector3.forward * movedir.z * speed, Space.Self);

	}

	void OnMove(InputValue value)
	{
		movedir.z = value.Get<Vector2>().y;
		movedir.x = value.Get<Vector2>().x;
	}
}

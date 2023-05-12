using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallControlor : MonoBehaviour
{
	// �������� ����
	// ������ٵ� ������ AddForce�� �����̰� ���� �ٴ� �÷��̾� ����
	Rigidbody rb;
	Vector3 movedir;

	[SerializeField]
	float moveSpeed;
	[SerializeField]
	float jumpPower;

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
		movedir.x = value.Get<Vector2>().x;
		movedir.z = value.Get<Vector2>().y;
	}

	void Move()
	{
		rb.AddForce(movedir * moveSpeed * Time.deltaTime, ForceMode.Force);
	}

	void OnJump(InputValue value) 
	{
		Jump();
	}

	void Jump()
	{
		rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
	}
}

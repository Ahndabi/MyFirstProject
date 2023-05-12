using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallControlor : MonoBehaviour
{
	// 공굴리기 구현
	// 리지드바디를 가지고 AddForce로 움직이고 점프 뛰는 플레이어 구현
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlor : MonoBehaviour
{
	Rigidbody rb;
	Vector3 moveDir;

	[SerializeField]
	float movePower;
	[SerializeField]
	float jumpPower;
	[SerializeField]
	float rotatePower;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		//Move();
		//Rotate();
		LookAt();
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
	}
	public void Move()
	{
		// 1.
		rb.AddForce(moveDir * movePower, ForceMode.Force);
		// ForceMode.Force = 지속적으로 힘을 가함.	Impulse = 퍽!하고 순간적인 힘

		// 2.
		transform.position += moveDir * Time.deltaTime;
		// Time.daltaTime : 1/s임. 속력으로 움직여줌. 한 프레임당 걸리는 시간에 대해 곱해야 속력으로 움직일 수 있음
		// transform.position은 위치 이동이라서 손을 떼면 바로 멈춤

		// 3. 
		transform.Translate(moveDir * Time.deltaTime, Space.Self);
		// Translate는 물체가 바라보는 방향이 됨. 오브젝트의 transform 기준으로 움직임
		// Space.Self 는 물체가 바라보는 방향(축)을 기준으로. World는 게임세상 축을 기준으로
	}


	public void Rotate()	// 회전
	{
		// transform.Rotate(Vector3.up, moveDir.x * rotatePower * Time.deltaTime, Space.Self);

	}

	public void LookAt()
	{
		transform.LookAt(new Vector3(0, 0, 0));		// 목적지를 정해주면 거기를 바라봄
	}


	void OnMove(InputValue value)
	{
		moveDir.x = value.Get<Vector2>().x;
		moveDir.z = value.Get<Vector2>().y;	// y는 상하.
		// y는 중력의 반대.(점프)
		// z는 앞뒤
	}

	void OnJump(InputValue value) 
	{
		Jump();
	}
}

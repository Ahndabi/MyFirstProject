using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
	// Move, OnMove, Rotate
	Rigidbody rb;
	Vector3 moveDir;
	[SerializeField] float movePower;
	[SerializeField] float jumpPower;
	[SerializeField] float rotatePower;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Move();
		//Rotate();
		//LookAt();
	}

	public void Move()
	{
		rb.AddForce(moveDir * movePower);
	}

	public void OnMove(InputValue value)    // input system에서 Move할 때 지정한 키를 누르면 OnMove가 호출되는 거임
	{
		moveDir.x = value.Get<Vector2>().x;
		moveDir.z = value.Get<Vector2>().y; // y는 상하.
											// y는 중력의 반대.(점프)
											// z는 앞뒤
	}

	public void Rotate()    // 회전
	{
		transform.Rotate(Vector3.up, moveDir.x * rotatePower * Time.deltaTime, Space.Self);

	}

	public void LookAt()    // 목표지점을 향해서 거기로 회전(?)
	{
		transform.LookAt(new Vector3(0, 0, 0));     // 목적지를 정해주면 거기를 바라봄
	}


	void OnJump(InputValue value)
	{
		Jump();
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
	}

}

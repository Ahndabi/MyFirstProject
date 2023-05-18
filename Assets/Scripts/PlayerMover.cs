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

	public void OnMove(InputValue value)    // input system���� Move�� �� ������ Ű�� ������ OnMove�� ȣ��Ǵ� ����
	{
		moveDir.x = value.Get<Vector2>().x;
		moveDir.z = value.Get<Vector2>().y; // y�� ����.
											// y�� �߷��� �ݴ�.(����)
											// z�� �յ�
	}

	public void Rotate()    // ȸ��
	{
		transform.Rotate(Vector3.up, moveDir.x * rotatePower * Time.deltaTime, Space.Self);

	}

	public void LookAt()    // ��ǥ������ ���ؼ� �ű�� ȸ��(?)
	{
		transform.LookAt(new Vector3(0, 0, 0));     // �������� �����ָ� �ű⸦ �ٶ�
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

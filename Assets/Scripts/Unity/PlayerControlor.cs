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
		// ForceMode.Force = ���������� ���� ����.	Impulse = ��!�ϰ� �������� ��

		// 2.
		transform.position += moveDir * Time.deltaTime;
		// Time.daltaTime : 1/s��. �ӷ����� ��������. �� �����Ӵ� �ɸ��� �ð��� ���� ���ؾ� �ӷ����� ������ �� ����
		// transform.position�� ��ġ �̵��̶� ���� ���� �ٷ� ����

		// 3. 
		transform.Translate(moveDir * Time.deltaTime, Space.Self);
		// Translate�� ��ü�� �ٶ󺸴� ������ ��. ������Ʈ�� transform �������� ������
		// Space.Self �� ��ü�� �ٶ󺸴� ����(��)�� ��������. World�� ���Ӽ��� ���� ��������
	}


	public void Rotate()	// ȸ��
	{
		// transform.Rotate(Vector3.up, moveDir.x * rotatePower * Time.deltaTime, Space.Self);

	}

	public void LookAt()
	{
		transform.LookAt(new Vector3(0, 0, 0));		// �������� �����ָ� �ű⸦ �ٶ�
	}


	void OnMove(InputValue value)
	{
		moveDir.x = value.Get<Vector2>().x;
		moveDir.z = value.Get<Vector2>().y;	// y�� ����.
		// y�� �߷��� �ݴ�.(����)
		// z�� �յ�
	}

	void OnJump(InputValue value) 
	{
		Jump();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankTransform : MonoBehaviour
{
	// Transform �̵� ��ũ ����
	// Transform ������Ʈ�� ������ Translate�� Rotate�� �̵�, ȸ���ϴ� ��ũ ����

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

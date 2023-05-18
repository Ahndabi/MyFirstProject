using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
	Rigidbody rb;
	Vector3 moveDir;
	[SerializeField] Animator animator;

	[SerializeField] float movePower;
	[SerializeField] float jumpPower;
	[SerializeField] float rotatePower;
	

	[Header("Shooter")]
	[SerializeField] GameObject bulletPrefabs;
	[SerializeField] Transform bulletPoint;     // �Ѿ˽�� ��ġ
												// [Serial~~~~] Bullet bulletPrefab�� ����
	[SerializeField] float repeatTime;			// �Ѿ� ��Ÿ��?

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		Move();
		//Rotate();
		//LookAt();
	}


	public void Move()
	{
		// 1.
		rb.AddForce(moveDir * movePower, ForceMode.Force);		// time.deltatime �� ������ �ȿ�����,,,��?
		// ForceMode.Force = ���������� ���� ����.	Impulse = ��!�ϰ� �������� ��

		// 2.
		// transform.position += moveDir * Time.deltaTime;
		// Time.daltaTime : 1/s��. �ӷ����� ��������. �� �����Ӵ� �ɸ��� �ð��� ���� ���ؾ� �ӷ����� ������ �� ����
		// transform.position�� ��ġ �̵��̶� ���� ���� �ٷ� ����

		// 3. 
		// transform.Translate(moveDir * Time.deltaTime, Space.Self);
		// Translate�� ��ü�� �ٶ󺸴� ������ ��. ������Ʈ�� transform �������� ������
		// Time.deltaTime = �� �����Ӵ� �ҿ�� �ð�.
		// Time.deltaTime = ��ǻ�͸��� �����ϰ� �̵��Ϸ��� �ӵ��� �����ϰ� ���ָ� ��. �ӵ��� �̵��ϴ� �� 
		// �׷��� �ӵ��� �����̴� ���� �����ϰ� ���� �� Time.deltatime�� ����
		// Space.Self �� ��ü�� �ٶ󺸴� ����(��)�� ��������. World�� ���Ӽ��� ���� ��������
		// ��ũ�� �������� �յڷ� ������(����(����)�� �������� �����̴� �� �ƴ�.)
		//	�� ���� �������� �ϰ� ������ Spcae.World �̰� ����
	}

	public void OnMove(InputValue value)    // input system���� Move�� �� ������ Ű�� ������ OnMove�� ȣ��Ǵ� ����
	{
		moveDir.x = value.Get<Vector2>().x;
		moveDir.z = value.Get<Vector2>().y; // y�� ����.
											// y�� �߷��� �ݴ�.(����)
											// z�� �յ�
	}

	public void Rotate()	// ȸ��
	{
		// transform.Rotate(Vector3.up, moveDir.x * rotatePower * Time.deltaTime, Space.Self);

	}

	public void LookAt()	// ��ǥ������ ���ؼ� �ű�� ȸ��(?)
	{
		transform.LookAt(new Vector3(0, 0, 0));		// �������� �����ָ� �ű⸦ �ٶ�
	}


	void OnJump(InputValue value) 
	{
		Jump();  
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
	}

	void OnFire(InputValue value)	// �����̽��ٸ� ������ ������ �Լ���
	{
		Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
		animator.SetTrigger("Fire");	// "" �ȿ��� �Ķ���� �̸�
	}

	Coroutine bulletRoutine;    // �Ѿ��� �����ϴ� ��ƾ
	IEnumerator BulletMakeRoutine()
	{
		while(true)
		{
			Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
			// Instantiate: �������� ���� ���ο� ���ӿ�����Ʈ�� �������
			// bulletPrefabs�� bulletPoint.position����, bulletPoint.rotation �������� ����.
			yield return new WaitForSeconds(repeatTime);	// �ݺ��� ������ �Ѿ� ��
		}
	}

	void OnRepeatFire(InputValue value)
	{
		if(value.isPressed)		// ������ ��
			bulletRoutine = StartCoroutine(BulletMakeRoutine());
		else					// ���� ��
			StopCoroutine(bulletRoutine);
	}
}

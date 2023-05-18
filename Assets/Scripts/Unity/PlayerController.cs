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
	[SerializeField] Transform bulletPoint;     // 총알쏘는 위치
												// [Serial~~~~] Bullet bulletPrefab도 가능
	[SerializeField] float repeatTime;			// 총알 쿨타임?

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
		rb.AddForce(moveDir * movePower, ForceMode.Force);		// time.deltatime 을 넣으면 안움지겨,,,왜?
		// ForceMode.Force = 지속적으로 힘을 가함.	Impulse = 퍽!하고 순간적인 힘

		// 2.
		// transform.position += moveDir * Time.deltaTime;
		// Time.daltaTime : 1/s임. 속력으로 움직여줌. 한 프레임당 걸리는 시간에 대해 곱해야 속력으로 움직일 수 있음
		// transform.position은 위치 이동이라서 손을 떼면 바로 멈춤

		// 3. 
		// transform.Translate(moveDir * Time.deltaTime, Space.Self);
		// Translate는 물체가 바라보는 방향이 됨. 오브젝트의 transform 기준으로 움직임
		// Time.deltaTime = 한 프레임당 소요된 시간.
		// Time.deltaTime = 컴퓨터마다 동일하게 이동하려면 속도를 일정하게 해주면 됨. 속도로 이동하는 것 
		// 그래서 속도로 움직이는 것을 구현하고 싶을 땐 Time.deltatime을 써줌
		// Space.Self 는 물체가 바라보는 방향(축)을 기준으로. World는 게임세상 축을 기준으로
		// 탱크를 기준으로 앞뒤로 움직임(세상(월드)를 기준으로 움직이는 게 아님.)
		//	ㄴ 월드 기준으로 하고 싶으면 Spcae.World 이거 ㄱㄱ
	}

	public void OnMove(InputValue value)    // input system에서 Move할 때 지정한 키를 누르면 OnMove가 호출되는 거임
	{
		moveDir.x = value.Get<Vector2>().x;
		moveDir.z = value.Get<Vector2>().y; // y는 상하.
											// y는 중력의 반대.(점프)
											// z는 앞뒤
	}

	public void Rotate()	// 회전
	{
		// transform.Rotate(Vector3.up, moveDir.x * rotatePower * Time.deltaTime, Space.Self);

	}

	public void LookAt()	// 목표지점을 향해서 거기로 회전(?)
	{
		transform.LookAt(new Vector3(0, 0, 0));		// 목적지를 정해주면 거기를 바라봄
	}


	void OnJump(InputValue value) 
	{
		Jump();  
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
	}

	void OnFire(InputValue value)	// 스페이스바를 누르면 반응할 함수임
	{
		Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
		animator.SetTrigger("Fire");	// "" 안에는 파라메터 이름
	}

	Coroutine bulletRoutine;    // 총알을 생성하는 루틴
	IEnumerator BulletMakeRoutine()
	{
		while(true)
		{
			Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
			// Instantiate: 프리팹을 씬에 새로운 게임오브젝트로 만들어줌
			// bulletPrefabs를 bulletPoint.position에서, bulletPoint.rotation 방향으로 만듦.
			yield return new WaitForSeconds(repeatTime);	// 반복할 때마다 총알 쏨
		}
	}

	void OnRepeatFire(InputValue value)
	{
		if(value.isPressed)		// 눌렀을 때
			bulletRoutine = StartCoroutine(BulletMakeRoutine());
		else					// 뗐을 때
			StopCoroutine(bulletRoutine);
	}
}

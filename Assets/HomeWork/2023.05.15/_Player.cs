using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class _Player : MonoBehaviour
{
	// 1. 생성시 앞으로 날아가는 총알 프리팹 만들기 & 2. 플레이어의 입력으로 총알 생성 구현
	[SerializeField] GameObject bulletPrefab;	// 총알 프리팹
	[SerializeField] Transform bulletPoint;     // 총구 위치
	[SerializeField] float bulletRepeat;		// 총알 반복하는 시간
	[SerializeField] AudioSource bulletAudio;   // 총 쏠 때 나오는 소리
	[SerializeField] CinemachineVirtualCamera CM2;	// 두 번째 카메라
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnFire(InputValue value)
	{
		bulletAudio.Play();
		Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
		// 총알 프리팹이 총구 위치에서 총구가 바라보는 방향으로 생성된다.
	}



	// 3. 코루틴을 이용하여 누르고 있는 동안 연사 구현
	Coroutine bulletRoutine;	// 총알을 생성하는 반복작업을 코루틴으로 만듦

	IEnumerator BulletMakeRoutine()		// 코루틴을 돌릴 수 있는 루틴
	{
		while(true)
		{
			Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
			// 총알을 생성한다.
			yield return new WaitForSeconds(bulletRepeat);	// bulletRepeat 만큼 기다린다.
		}
	}

	void OnRepeatFire(InputValue value)
	{
		if (value.isPressed)	// value (Left Ctrl)을 누르고 있을 땐
			bulletRoutine = StartCoroutine(BulletMakeRoutine());    // BulletMakeRoutine을 시작한다.
		else                    // 뗐을 땐
			StopCoroutine(bulletRoutine);		// 코루틴을 멈춘다.
	}


	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))    // 왼쪽 쉬프트 키 누르면
		{
			CM2.Priority = 8;					// 두 번째 카메라의 우선순위가 8로 바뀐다.
		}
		else if(Input.GetKeyUp(KeyCode.RightShift))		// 떼면,
		{
			CM2.Priority = 11;					// 11로 바뀐다.
		}
	}
}

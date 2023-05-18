using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
	// OnFire, Fire, repeatTime

	[Header("Shooter")]
	[SerializeField] GameObject bulletPrefabs;
	[SerializeField] Animator animator;
	[SerializeField] Transform bulletPoint;     // 총알쏘는 위치
												// [Serial~~~~] Bullet bulletPrefab도 가능
	[SerializeField] float repeatTime;          // 총알 쿨타임?

	public UnityEvent OnFired;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void OnFire(InputValue value)   // 스페이스바를 누르면 반응할 함수임
	{
		Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
		animator.SetTrigger("Fire");    // "" 안에는 파라메터 이름

		GameManager.Data.AddShootCount(1);
		OnFired?.Invoke();		// 이벤트 호출 (Fire 할 때마다 오디오 추가, 카메라 추가, 효과 추가 등등을
								// 소스를 수정하지 않아도 인스펙터 창에서쉽게 할 수 있음)
	}

	Coroutine bulletRoutine;    // 총알을 생성하는 루틴
	IEnumerator BulletMakeRoutine()
	{
		while (true)
		{
			Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
			// Instantiate: 프리팹을 씬에 새로운 게임오브젝트로 만들어줌
			// bulletPrefabs를 bulletPoint.position에서, bulletPoint.rotation 방향으로 만듦.
			yield return new WaitForSeconds(repeatTime);    // 반복할 때마다 총알 쏨
		}
	}

	void OnRepeatFire(InputValue value)
	{
		if (value.isPressed)        // 눌렀을 때
			bulletRoutine = StartCoroutine(BulletMakeRoutine());
		else					    // 뗐을 때
			StopCoroutine(bulletRoutine);
	}
}

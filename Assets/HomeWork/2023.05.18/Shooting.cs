using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject bulletPoint;
	[SerializeField] Animator animator;

	public UnityEvent OnFired;


	public void OnFire(InputValue value)
	{
		Fire();

		GameManager.Data2.AddShootingCount(1);		// Data2에 있는 AddShootingCount에 1을 매개변수로 넣는다.
		OnFired?.Invoke();      // 이벤트 호출 (Fire 할 때마다 오디오 추가, 카메라 추가, 효과 추가 등등을
								// 소스를 수정하지 않아도 인스펙터 창에서쉽게 할 수 있음)
	}

	public void Fire()
	{
		Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
		animator.SetTrigger("Fire");
		Destroy(bullet, 2f);
	}
}

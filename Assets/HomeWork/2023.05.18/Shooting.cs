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

		GameManager.Data2.AddShootingCount(1);		// Data2�� �ִ� AddShootingCount�� 1�� �Ű������� �ִ´�.
		OnFired?.Invoke();      // �̺�Ʈ ȣ�� (Fire �� ������ ����� �߰�, ī�޶� �߰�, ȿ�� �߰� �����
								// �ҽ��� �������� �ʾƵ� �ν����� â�������� �� �� ����)
	}

	public void Fire()
	{
		Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
		animator.SetTrigger("Fire");
		Destroy(bullet, 2f);
	}
}

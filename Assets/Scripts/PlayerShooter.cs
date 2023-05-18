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
	[SerializeField] Transform bulletPoint;     // �Ѿ˽�� ��ġ
												// [Serial~~~~] Bullet bulletPrefab�� ����
	[SerializeField] float repeatTime;          // �Ѿ� ��Ÿ��?

	public UnityEvent OnFired;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void OnFire(InputValue value)   // �����̽��ٸ� ������ ������ �Լ���
	{
		Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
		animator.SetTrigger("Fire");    // "" �ȿ��� �Ķ���� �̸�

		GameManager.Data.AddShootCount(1);
		OnFired?.Invoke();		// �̺�Ʈ ȣ�� (Fire �� ������ ����� �߰�, ī�޶� �߰�, ȿ�� �߰� �����
								// �ҽ��� �������� �ʾƵ� �ν����� â�������� �� �� ����)
	}

	Coroutine bulletRoutine;    // �Ѿ��� �����ϴ� ��ƾ
	IEnumerator BulletMakeRoutine()
	{
		while (true)
		{
			Instantiate(bulletPrefabs, bulletPoint.position, bulletPoint.rotation);
			// Instantiate: �������� ���� ���ο� ���ӿ�����Ʈ�� �������
			// bulletPrefabs�� bulletPoint.position����, bulletPoint.rotation �������� ����.
			yield return new WaitForSeconds(repeatTime);    // �ݺ��� ������ �Ѿ� ��
		}
	}

	void OnRepeatFire(InputValue value)
	{
		if (value.isPressed)        // ������ ��
			bulletRoutine = StartCoroutine(BulletMakeRoutine());
		else					    // ���� ��
			StopCoroutine(bulletRoutine);
	}
}

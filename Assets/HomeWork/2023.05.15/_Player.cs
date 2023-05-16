using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class _Player : MonoBehaviour
{
	// 1. ������ ������ ���ư��� �Ѿ� ������ ����� & 2. �÷��̾��� �Է����� �Ѿ� ���� ����
	[SerializeField] GameObject bulletPrefab;	// �Ѿ� ������
	[SerializeField] Transform bulletPoint;     // �ѱ� ��ġ
	[SerializeField] float bulletRepeat;		// �Ѿ� �ݺ��ϴ� �ð�
	[SerializeField] AudioSource bulletAudio;   // �� �� �� ������ �Ҹ�
	[SerializeField] CinemachineVirtualCamera CM2;	// �� ��° ī�޶�
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnFire(InputValue value)
	{
		bulletAudio.Play();
		Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
		// �Ѿ� �������� �ѱ� ��ġ���� �ѱ��� �ٶ󺸴� �������� �����ȴ�.
	}



	// 3. �ڷ�ƾ�� �̿��Ͽ� ������ �ִ� ���� ���� ����
	Coroutine bulletRoutine;	// �Ѿ��� �����ϴ� �ݺ��۾��� �ڷ�ƾ���� ����

	IEnumerator BulletMakeRoutine()		// �ڷ�ƾ�� ���� �� �ִ� ��ƾ
	{
		while(true)
		{
			Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
			// �Ѿ��� �����Ѵ�.
			yield return new WaitForSeconds(bulletRepeat);	// bulletRepeat ��ŭ ��ٸ���.
		}
	}

	void OnRepeatFire(InputValue value)
	{
		if (value.isPressed)	// value (Left Ctrl)�� ������ ���� ��
			bulletRoutine = StartCoroutine(BulletMakeRoutine());    // BulletMakeRoutine�� �����Ѵ�.
		else                    // ���� ��
			StopCoroutine(bulletRoutine);		// �ڷ�ƾ�� �����.
	}


	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))    // ���� ����Ʈ Ű ������
		{
			CM2.Priority = 8;					// �� ��° ī�޶��� �켱������ 8�� �ٲ��.
		}
		else if(Input.GetKeyUp(KeyCode.RightShift))		// ����,
		{
			CM2.Priority = 11;					// 11�� �ٲ��.
		}
	}
}

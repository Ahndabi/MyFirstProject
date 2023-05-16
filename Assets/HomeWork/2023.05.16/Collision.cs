using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
	[SerializeField] GameObject bulletEffect;
	[SerializeField] AudioSource explostion;
	
	// 1. �߻��� ��ź�� ���� �΋H���� ������� ���� &  2. ���� ��ġ�� ����ȿ�� �߰�
	private void OnCollisionEnter(UnityEngine.Collision collision)
	{
		Instantiate(bulletEffect, gameObject.transform.position, gameObject.transform.rotation);
		//explostion.Play();
		Destroy(bulletEffect, 1f);
		Destroy(gameObject);
	}


	// 3. ��ź�� �÷��̾ ��ź���� �浹���� �ʵ��� ����
	// layer�� �ذ��Ѵ�.
	// �ν����� â�� �ִ� layer�� ���� Player ���̾�, Bullet���̾ ������ְ� ���� �°� ���̾ �����Ѵ�.
	// Edit - Project Setting���� Physics�� �ִ� ���̾� �۾��� �Ѵ�.
	// Player�� Bullet�� �浹���� �ʵ��� üũ�� �����ϰ� Bullet ������ �浹���� �ʵ��� üũ�� �����Ѵ�.



	// 4. ���� ����ƮŰ ������ �������� ���� ������ ī�޶� �̵�, ���� �ٽ� ���� ��ġ��
	// �÷��̾� ��ũ��Ʈ���� [SerializeField] CinemachineVirtualCamera CM2; �� �ϳ� ������ش�.
	// CM1 (ù��° ī�޶�)�� �켱������ 9�� �����ϰ� ���� �ڵ�� �����Ѵ�.
	/*
	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))    // ���� ����Ʈ Ű ������
		{
			CM2.Priority = 8;                   // �� ��° ī�޶��� �켱������ 8�� �ٲ��.
		}
		else if (Input.GetKeyUp(KeyCode.RightShift))        // ����,
		{
			CM2.Priority = 11;                  // 11�� �ٲ��.
		}
	}*/



	// 5. ��ũ�� ��ź �� �� ��� �Ҹ�
	// Player ��ũ��Ʈ�� AudioSource�� �ϳ� ������ְ� OnFire�� AudioSource.Play(); �� �����Ų��.

	// 6. 5���� �����ϰ� �ߴ�.	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _bullet : MonoBehaviour
{
	// 1. ������ ������ ���ư��� �Ѿ� ������ ����� & 2. �÷��̾��� �Է����� �Ѿ� ���� ����

	Rigidbody rb;
	[SerializeField] float Speed;   // �Ѿ� ���ǵ�

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}


	private void Start()
	{
		rb.velocity = transform.forward * Speed;   // gameobject�� �ٶ󺸴� �������� ������ ���ư�
		Destroy(gameObject, 2f);
	}


	// 3. �ڷ�ƾ�� �̿��Ͽ� ������ �ִ� ���� ���� ����

}

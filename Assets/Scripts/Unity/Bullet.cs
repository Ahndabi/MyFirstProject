using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// rigidbody�� �� �ʿ��� ��ũ��Ʈ�ε� �ν����Ϳ��� �����ϰ� rigidbody�� �� �ִ� �Ǽ��� �� �ϰ� �ʹٸ�?
[RequireComponent(typeof(Rigidbody))]	// rigidbody������Ʈ�� �䱸��. �׷� ��ũ��Ʈ ������ �ڵ����� rigid�� �߰���
public class Bullet : MonoBehaviour
{
	[SerializeField] float bulletSpeed;
	[SerializeField] GameObject explosionEffect;	// ������ ����Ʈ
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		rb.velocity = transform.forward * bulletSpeed;  // �ٶ󺸴� ������ �չ������� ������� Vector3���� transform���� ��
														// Vector3.forward�� world�� �������� ������ ���ư��Ե�
		Destroy(gameObject, 5f);			// 5�� �ڿ� �������
	}

	private void OnCollisionEnter(Collision collision)	// �浹���� ��
	{
		Instantiate(explosionEffect, transform.position, transform.rotation);
		Destroy(gameObject);	// �浹�ϸ� �Ѿ� ������
	}
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// rigidbody가 꼭 필요한 스크립트인데 인스펙터에서 깜빡하고 rigidbody를 안 넣는 실수를 안 하고 싶다면?
[RequireComponent(typeof(Rigidbody))]	// rigidbody컴포넌트를 요구함. 그럼 스크립트 넣으면 자동으로 rigid도 추가됨
public class Bullet : MonoBehaviour
{
	[SerializeField] float bulletSpeed;
	[SerializeField] GameObject explosionEffect;	// 터지는 이펙트
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		rb.velocity = transform.forward * bulletSpeed;  // 바라보는 방향을 앞방향으로 잡기위해 Vector3말고 transform으로 함
														// Vector3.forward는 world를 기준으로 앞으로 나아가게됨
		Destroy(gameObject, 5f);			// 5초 뒤에 사라지기
	}

	private void OnCollisionEnter(Collision collision)	// 충돌했을 때
	{
		Instantiate(explosionEffect, transform.position, transform.rotation);
		Destroy(gameObject);	// 충돌하면 총알 없어짐
	}
}
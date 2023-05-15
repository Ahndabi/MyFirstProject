using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _bullet : MonoBehaviour
{
	// 1. 생성시 앞으로 날아가는 총알 프리팹 만들기 & 2. 플레이어의 입력으로 총알 생성 구현

	Rigidbody rb;
	[SerializeField] float Speed;   // 총알 스피드

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}


	private void Start()
	{
		rb.velocity = transform.forward * Speed;   // gameobject가 바라보는 방향으로 앞으로 나아감
		Destroy(gameObject, 2f);
	}


	// 3. 코루틴을 이용하여 누르고 있는 동안 연사 구현

}

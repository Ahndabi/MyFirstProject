using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
	[SerializeField] GameObject bulletEffect;
	[SerializeField] AudioSource explostion;
	
	// 1. 발사한 포탄이 벽에 부딫히면 사라지게 구현 &  2. 터진 위치에 폭발효과 추가
	private void OnCollisionEnter(UnityEngine.Collision collision)
	{
		Instantiate(bulletEffect, gameObject.transform.position, gameObject.transform.rotation);
		//explostion.Play();
		Destroy(bulletEffect, 1f);
		Destroy(gameObject);
	}


	// 3. 포탄이 플레이어나 포탄과는 충돌하지 않도록 구현
	// layer로 해결한다.
	// 인스펙터 창에 있는 layer에 들어가서 Player 레이어, Bullet레이어를 만들어주고 각각 맞게 레이어를 설정한다.
	// Edit - Project Setting에서 Physics에 있는 레이어 작업을 한다.
	// Player와 Bullet은 충돌하지 않도록 체크를 해제하고 Bullet 끼리도 충돌하지 않도록 체크를 해제한다.



	// 4. 왼쪽 쉬프트키 누르면 포구에서 앞을 보도록 카메라 이동, 때면 다시 원래 위치로
	// 플레이어 스크립트에서 [SerializeField] CinemachineVirtualCamera CM2; 를 하나 만들어준다.
	// CM1 (첫번째 카메라)의 우선순위는 9로 설정하고 밑의 코드로 구현한다.
	/*
	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))    // 왼쪽 쉬프트 키 누르면
		{
			CM2.Priority = 8;                   // 두 번째 카메라의 우선순위가 8로 바뀐다.
		}
		else if (Input.GetKeyUp(KeyCode.RightShift))        // 떼면,
		{
			CM2.Priority = 11;                  // 11로 바뀐다.
		}
	}*/



	// 5. 탱크가 포탄 쏠 때 쏘는 소리
	// Player 스크립트에 AudioSource를 하나 만들어주고 OnFire에 AudioSource.Play(); 를 실행시킨다.

	// 6. 5번과 동일하게 했다.	
}

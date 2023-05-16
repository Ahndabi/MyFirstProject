using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCollsion : MonoBehaviour
{
	/************************************************************************
	 * 충돌체
	 * 
	 * 물리적 충돌을 위해 게임오브젝트의 모양을 정의
	 * 게임오브젝트의 표현인 메시와 똑같을 필요는 없음
	 * 충돌체가 충돌상황에 있을 경우 유니티 충돌 메시지를 받아 상황을 확인
	 * 겹쳐있는 것을 판단하는 것
	 ************************************************************************/
	// GameObject에 rigidbody가 있는 상태에서 충돌을 받으면 밀려나감. (외부에 힘을 받으면 내가밀림)
	// 정적 충돌체 : rigidbody 없이 그 자리에 계속 고정적으로 있음 (ex. 건물, 땅)
	// 정적 충돌체끼리는 충돌 연산을 X (서로 충돌이 안 됨)
	// 리지드바디 콜라이더끼리만 충돌됨
	// Rigidbody - isKenematic 은 rigidbody가 있지만 밀리고 싶지 않을 때

	// <유니티 충돌 메시지>
	private void OnCollisionEnter(Collision collision)
	{
		// 충돌이 진입했을 때 발생
		Debug.Log("OnCollisionEnter");
	}

	private void OnCollisionStay(Collision collision)
	{
		// 계속 접착되어 있을 때 (충돌 중일 때)
		Debug.Log("OnCollisionStay");
	}

	private void OnCollisionExit(Collision collision)
	{
		// 헤어졌을 때 (충돌 끝났을 때)
		Debug.Log("OnCollisionExit");
	}


	/************************************************************************
	 * 트리거 충돌체
	 * 
	 * 하나의 충돌체가 충돌을 일으키지 않고 다른 충돌체의 공간에 들어가는 것을 감지
	 * 트리거가 겹침상황에 있을 경우 유니티 트리거 메시지를 받아 상황을 확인
	 * 충돌로 밀어내는 거 없음. 겹침 여부만 판단! (ex. 아이템 먹음, 던전에 진입했다 등)
	 ************************************************************************/
	// Collider - is Trigger 체크하면 됨
	// 정적 트리거 (움직이지 않는 트리거)

	// <유니티 트리거 메시지>
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter");
	}

	private void OnTriggerStay(Collider other)
	{
		Debug.Log("OnTriggerStay");
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("OnTriggerExit");
	}

	// <레이어기반 충돌 감지>
	// 게임오브젝트의 레이어를 활용하여 충돌체간의 충돌가능 여부를 설정 가능
	// edit -> ProjectSettings -> Physics 에서 설정 가능


	// <충돌체 종류>
	// (1) 정적 충돌체 (Static Collider)
	// Rigidbody가 없는 충돌체, 외부에 힘에 움직이지 않음
	// 절대로 움직이지 않는 지형, 구성요소에 주로 사용

	// (2) 리지드바디 충돌체 (Rigidbody Collider)
	// Rigidbody가 있는 충돌체, 외부에 힘을 받아 움직임
	// 충돌할 수 있으며 물리를 사용하는 게임 내 가장 흔히 사용되는 충돌체에 사용

	// (3) 키네마틱 충돌체 (Kinematic Collider)
	// Kinematic Rigidbody가 있는 충돌체, 외부의 힘에 반응하지 않음
	// 움직이지만 외부 충격에는 밀리지 않는 물체(밀어내는 장애물, 미닫이문 등)등 에 사용
	// kinematic 상태를 활성화/비활성화 하여 움직임 여부를 설정할 경우 사용


	// <충돌체 상호작용 매트릭스>
	// 편의상 정적충돌체(SC), 리지드바디충돌체(RC), 키네마틱충돌체(KC)로 표현
	// 편의상 정적트리거(ST), 리지드바디트리거(RT), 키네마틱트리거(KT)로 표현

	// 충돌시 충돌 메시지가 전송
	//		SC	RC	KC
	// SC		 O	
	// RC	 O	 O	 O
	// KC		 O	

	// 충돌시 트리거 메시지가 전송
	//		SC	RC	KC	ST	RT	KT
	// SC					 O	 O
	// RC				 O	 O	 O
	// KC				 O	 O	 O
	// ST		 O	 O		 O	 O
	// RT	 O	 O	 O	 O	 O	 O
	// KT	 O	 O	 O	 O	 O	 O
}



// Ctrl Shift F 하면 바라보는 곳에서 바로 물체 반영시킬 수 있음
// 
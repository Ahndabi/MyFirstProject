using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInput : MonoBehaviour
{
	/************************************************************************
	 * 유니티 입력
	 * 
	 * 유니티에서 사용자의 명령을 감지할 수 있는 수단
	 * 사용자는 외부 장치를 이용하여 게임을 제어할 수 있음
	 * 유니티는 다양한 타입의 입력기기(키보드 및 마우스, 조이스틱, 터치스크린 등)를 지원
	 ************************************************************************/
	// Game 씬에서 입력해야지 반영이 됨.
	private void Update()
	{
		InputByInputManager();
	}

	// <Device>
	// 특정한 장치를 기준으로 입력 감지
	// 특정한 장치의 입력을 감지하기 때문에 여러 플랫폼에 대응이 어려움
	//********* 이거 쓰지말래! 이거는 모바일용, 조이스틱용, 마우스용,, 다 따로 만들어야 한대!!!!*********
	private void InputByDevice()
	{
		// 키보드 입력.		GetKey는 키보드이구 bool 형임
		if (Input.GetKeyUp(KeyCode.Space))
			Debug.Log("Key Up");
		if (Input.GetKeyDown(KeyCode.Space))
			Debug.Log("Key Down");
		if (Input.GetKey(KeyCode.Space))
			Debug.Log("Key pressing");

		// 마우스 입력
		if (Input.GetMouseButton(0))        // 0: 좌클릭	1: 우클릭
			Debug.Log("Mouse Left button pressing");
		if (Input.GetMouseButtonDown(0))
			Debug.Log("Mouse left button is down");
		if (Input.GetMouseButtonUp(0))
			Debug.Log("Mouse left button is up");
	}


	//******************** 여기부터 사용해도 된댕**********************
	// <InputManager>
	// 여러 장치의 입력을 입력매니저에 이름과 입력을 정의
	// 입력매니저의 이름으로 정의한 입력의 변경사항을 확인
	// 유니티 에디터의 Edit -> Project Settings -> Input Manager 에서 관리

	// 단, 유니티 초창기의 방식이기 때문에 키보드, 마우스, 조이스틱에 대한 장치만을 고려함
	// 추가) VR Oculus Integraion Kit 같은 경우 입력매니저와 유사한 방식을 사용
	// VR, 모바일기기에서는 InputManager가 좀 부족,,,

	private void InputByInputManager()
	{
		// 버튼 입력
		// Fire1 : 키보드(Left Ctrl), 마우스(Left Button), 조이스틱(button0)으로 정의됨
		if (Input.GetButton("Fire1"))
			Debug.Log("Fire1 is pressing");
		if (Input.GetButtonDown("Fire1"))
			Debug.Log("Fire1 is down");
		if (Input.GetButtonUp("Fire1"))
			Debug.Log("Fire1 is up");

		// 축 입력
		// Horizontal(수평) : 키보드(a,d / ←, →), 조이스틱(왼쪽 아날로그스틱 좌우)
		float x = Input.GetAxis("Horizontal");
		// Vertical(수직) : 키보드(w,s / ↑, ↓), 조이스틱(왼쪽 아날로그스틱 상하)
		float y = Input.GetAxis("Vertical");
		Debug.Log($"{x}, {y}");
	}

	// <InputSystem>
	// Unity 2019.1 부터 지원하게 된 입력방식
	// 컴포넌트를 통해 입력의 변경사항을 확인
	// GamePad, JoyStick, Mouse, Keyboard, Pointer, Pen, TouchScreen, XR 기기 등을 지원
	// 우린 이걸 사용할 거야!!

	private void InputByInputSystem()
	{
		// InputSystem은 이벤트 방식으로 구현됨
		// Update마다 입력변경사항을 확인하는 방식 대신 변경이 있을 경우 이벤트로 확인
		// 메시지를 통해 받는 방식과 이벤트 함수를 직접 연결하는 방식 등으로 구성
	}

	void OnMove(InputValue value)
	{
		Vector2 dir = value.Get<Vector2>();
	}

	void OnJump(InputValue value) 
	{
		bool isPress = value.isPressed;
	}
}

// 유니티 새 프로젝트 만들기에서 코어 - Third Person 이거 좋대! 3D의 이동 구현이 잘 되어 있대
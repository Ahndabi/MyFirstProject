using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//========================================
//##			디자인 패턴 MVC			##
//========================================
/*
	MVC(Model-View-Controller) 패턴 :
	사용자 인터페이스, 데이터, 논리로직을 분리하여 프로그램을 관리하는 패턴

	<구현>
	Model :
		프로그램의 데이터
		Controller에 의해 갱신
		데이터의 변경을 View에게 알림
	View :
		사용자 인터페이스
		Model의 데이터를 기반으로 사용자에게 내용 표현
		사용자에게 입력을 받아 Controller에게 알림
	Controller	: 
		논리로직
		View의 입력을 받아 논리로직을 처리
		논리로직의 결과를 Model에 갱신

	view -> controller -> model -> view....
	view에 controller구현하지 말고, controller에 model 구현하지 말고,, 각각 분리해서! 구현하자!! = MVC 패턴~!

	장점 :
	1. 설계패턴 중 가장 단순하게 구현가능
	2. 프로그램의 구성 요소를 영향없이 쉽게 고칠 수 있도록 제안
	3. 유지보수성, 어플리케이션의 확장성, 유연성과 코드재사용성이 좋아짐

	단점 :
	1. Model과 View의 의존성이 높음

	그외 :
	MVC 패턴의 파생형인 MVP(Model-View-Presenter), MVVM(Model-View-ViewModel) 패턴이 있음
*/

public class Model
{
	private int data;
	public int Data
	{
		set
		{
			Debug.Log("[Model] Model changed event");
			OnDataChanged?.Invoke(value);
			data = value;
		}
		get
		{
			return data;
		}
	}

	public UnityAction<int> OnDataChanged;		// 데이터가 바뀌면 이벤트가 발생하게끔
}

public class View
{
	public UnityAction OnInputed;

	public void UpdateData(int data)	// 출력
	{
		Debug.Log("[View] Set data");
	}

	public void Input()		// 입력
	{
		Debug.Log("[View] Detect input");
		OnInputed?.Invoke();
	}
}

public class Controller
{
	public Model data;

	public void Logic()		// 연산
	{
		Debug.Log("[Controller] Logic");
		data.Data += 1;
	}
}

public class MVCTester
{
	public void Test()
	{
		Model model = new Model();
		View view = new View();
		Controller controller = new Controller();

		model.OnDataChanged += view.UpdateData;		// UI갱신 추가
		view.OnInputed += controller.Logic;			// 논리로직이 동작하는 것을 추가
		controller.data = model;					//

		view.Input();		// 입력만 했을 때
		// 1. [View] Dectect input			// 입력감지
		// 2. [Controller] Logic		
		// 3. [Model] Model change event
		// 4. [View] Set Data				// 결과가 view로 보임
	}
}
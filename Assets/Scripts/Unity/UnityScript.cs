using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityScript : MonoBehaviour    // 반드시MonoBehaviour를 상속 받아야 함
{
	/************************************************************************
	 * 컴포넌트 (Component)
	 * 
	 * 특정한 기능을 수행할 수 있도록 구성한 작은 기능적 단위
	 * 게임오브젝트의 작동과 관련한 부품
	 * 게임오브젝트에 추가, 삭제하는 방식의 조립형 부품
	 ************************************************************************/

	/************************************************************************
	 * MonoBehaviour
	 * 
	 * 컴포넌트를 기본클래스로 하는 클래스로 유니티 스크립트가 파생되는 기본 클래스
	 * 게임 오브젝트에 스크립트를 컴포넌트로서 연결할 수 있는 구성을 제공
	 * 스크립트 직렬화 기능, 유니티메시지 이벤트를 받는 기능, 코루틴 기능을 포함함
	 ***********************************************************************/

	// <스크립트 직렬화 기능>
	// 인스펙터 창에서 컴포넌트의 맴버변수 값을 확인하거나 변경하는 기능
	// 컴포넌트의 값형식 데이터를 확인하거나 변경
	// 컴포넌트의 참조형식 데이터를 드래그 앤 드랍 방식으로 연결
	// 인스펙터 창의 값이 스크립트 안의 값보다 더 우선임

	// private는 인스펙터 창에서 안 보임

	// <인스펙터창 직렬화가 가능한 자료형>
	[Header("C# Type")]
	public bool boolValue;
	public int intValue;
	public float floatValue;
	public string stringValue;
	// 그 외 기본 자료형

	// 기본 자료형의 선형자료구조
	public int[] array;
	public List<int> list;

	[Header("Unity Type")]
	public Vector3 vector3;		// 3차원 게임 x, y, z축	(2차원 게임은 Vector2)
	public Color color;
	public LayerMask layerMask;
	public AnimationCurve curve;
	public Gradient gradient;

	[Header("Unity GameObject")]
	public GameObject obj;

	[Header("Unity Component")]
	public new Transform transform;
	public new Rigidbody rigidbody;
	public new Collider collider;

	[Header("Unity Event")]
	public UnityEvent OnEvent;

	// <어트리뷰트>
	// 클래스, 프로퍼티 또는 함수 위에 명시하여 특별한 동작을 나타낼 수 있는 마커
	// 코드에 직접적으로 영향을 미치는 건 아니지만 속성 같은 것을 표시
	[Space(30)]

	[Header("Unity Attribute")]
	[SerializeField]	 // private지만 인스펙터에서 보이게 함
	private int privateValue;
	[HideInInspector]	 // public이지만 인스펙터에서 안 보이게 함
	public int publicValue;

	[Range(0, 10)]		 // 범위 지정
	public float rangeValue;

	[TextArea(3, 5)]	 // 텍스트를 여러 줄로 쓸 수 있음
	public string textField;
}

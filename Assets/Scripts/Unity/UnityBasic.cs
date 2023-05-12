using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
	public GameObject player;
	public AudioSource audiosource;
	// 컴포넌트가 게임오브젝트에 접근할 수 있는 방법. gameObject를 써주면 댐!
	// gameObject : 이 컴포넌트가 붙어있는 gameObject를 불러와준다.
	// 컴포넌트의 gameObject가 null이면 안됨. null이면 애초에 이 컴포넌트가 무용지물이니.
	private void Start()
	{
		GameObjectBasic();
	}
	public void GameObjectBasic()
	{
		// <게임오브젝트 접근>
		// 컴포넌트가 붙어있는 게임오브젝트는 gameObject 속성을 이용하여 접근가능
		// gameObject;					  // 컴포넌트가 붙어있는 게임오브젝트
		// gameObject.name;               // 게임오브젝트의 이름 접근
		// gameObject.activeSelf;         // 게임오브젝트의 활성화 여부 접근
		// gameObject.tag;                // 게임오브젝트의 태그 접근
		// gameObject.layer;              // 게임오브젝트의 레이어 접근

		player = GameObject.Find("Player");		// 이름으로 찾기
		// 만약 이름이 같은 오브젝트가 여러 개일 경우, 가장 먼저 찾은 오브젝트가 됨. (그래서 별로 좋은 방법X)
		player = GameObject.FindGameObjectWithTag("Player");    // 태그로 찾기
		// 그래서 이렇게 태그로 찾는 게 더 좋음
		// 같은 태그가 여러 개 있는 경우 FindGameObjectsWithTag를 씀 s붙음(그래서 얜 배열임)

		// <게임오브젝트 생성>
		GameObject newobject = new GameObject();

		// <게임오브젝트 삭제>
		Destroy(newobject);		// (newobject, 5f) 이러면 5초 뒤에 삭제됨. 지연삭제
	}

	public void ComponentBasic()
	{   // 컴포넌트용 기본함수
		// <게임오브젝트 내 컴포넌트 접근>
		audiosource = GetComponent<AudioSource>();
		// 같은 오브젝트에 있는 컴포넌트(내 형제 컴포넌트)를 찾는다.
		// 컴포넌트에서 GetComponent를 사용할 경우 부착되어 있는 게임오브젝트를 기준으로 접근
		audiosource = gameObject.GetComponent<AudioSource>(); // 게임오브젝트의 컴포넌트 접근
		GetComponents<AudioSource>();	// 여러 개 찾는 경우. GetComponents (반환형 배열임)

		// 만약 자식 오브젝트의 컴포넌트를 찾고싶다? (나 포함)
		GetComponentInChildren<AudioSource>();  // 자식 게임오브젝트 포함 컴포넌트 접근
		GetComponentsInChildren<AudioSource>(); // 자식오브젝트 포함 여러 컴포넌트들 접근(자주쓰임)

		// 부모는 자식보다 덜 쓰임. 잘 안 쓰인대
		gameObject.GetComponentInParent<AudioSource>();      // 부모 게임오브젝트 포함 컴포넌트 접근
		gameObject.GetComponentsInParent<AudioSource>();    // 부모 게임오브젝트 포함 컴포넌트들 접근

		// <컴포넌트 탐색>		 시간이 많이 걸림..
		FindObjectOfType<AudioSource>();	// 씬 내의 컴포넌트 탐색
		FindObjectsOfType<AudioSource>();   // 씬 내의 모든 컴포넌트 탐색
											// 매 프레임마다 찾는 경우 사용하는 것을 권장X. 한 번 찾아놓고 쭉--이걸 차라리!!

		// <컴포넌트 추가>
		// Rigidbody rigid = new Rigidbody();
		// 오브젝트에 컴포넌트가 안 붙어 있으면 가능하나 의미없음, 컴포넌트는 게임오브젝트에 부착되어 동작함에 의미가 있음
		AudioSource s = gameObject.AddComponent<AudioSource>();     // 게임오브젝트에 컴포넌트 추가

		// <컴포넌트 삭제>
		Destroy(GetComponent<Collider>());
	}
}

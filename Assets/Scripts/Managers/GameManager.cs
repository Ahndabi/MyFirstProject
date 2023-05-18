using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	private static DataManager dataManager;		// DataManager도 싱글톤으로 사용!
	static DataManager2 dataManager2;	// 실습
	public static GameManager Instance { get { return instance; } }		// 인스턴스 프로퍼티
	public static DataManager Data { get { return dataManager; } }
	public static DataManager2 Data2 { get { return dataManager2; } }	// 실습

	private void Awake()
	{
		if (instance != null)	
		{
			Destroy(this);	// instance가 이미 있었을 땐 this(컴포넌트)를 지움 (this는 이 컴포넌트니까 이 스크립트야)
			return;
		}
		instance = this;

		// 유니티는 컴포넌트 형식이라서 씬이 전환될 때도 이걸 유지시켜줘야돼 - 그래서 DontDestroyOnLoad를 써주는거야. 다른씬에서도  없어지지 않도록
		// (마을에선 골드 100이었는데 던전 들어가면 골드 없어짐? 말이안됨)
		DontDestroyOnLoad(this);	// 씬을 왔다갔다 해도 this는 안 지워짐!
		instance = this;
		InitManager();

		InitManager2();
		// 근데 만약 아예 안 만들면? 아예 안 만들었었어도 게임 시작되면 자동으로 게임매니저 싱글톤 하나는 만들어져야해.
	} 

	private void OnDestroy()
	{
		if (instance == this)
			instance = null;
	}
	
	void InitManager()		// DataManager도 초기화를 해주는 작업!
	{
		// DataManager init
		GameObject dataObj = new GameObject() { name = "DataManager" };
		dataObj.transform.SetParent(transform);
		dataManager = dataObj.AddComponent<DataManager>();
	}
	// 게임 시작하면 DataManager는 GameManager의 하위자식으로 생겨남



	//**************실습*************
	void InitManager2()
	{
		GameObject dataOb = new GameObject() { name = "DataManager2" };
		dataOb.transform.SetParent(transform);
		dataManager2 = dataOb.AddComponent<DataManager2>();
	}
}
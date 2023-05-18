using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 게임 시작하자마자 해야 할 작업들
public class GameSetting		// monobehavir 지웠음
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	// 이거를 static 앞에 붙여주면 게임 시작할 때 호출시켜줌.
	// 그래서 게임 시작하면 싱글톤 패턴이 하나가 무조건 생김.

	private static void Init()
	{
		// 게임 시작하기 전 필요한 설정들
		if (GameManager.Instance == null)   // 싱글톤을 한 번도 안 만들었다.
		{
			GameObject gameManager = new GameObject() { name = "GameManager" };
			gameManager.AddComponent<GameManager>();
		}
	}
}
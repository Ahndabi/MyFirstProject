using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// ���� �������ڸ��� �ؾ� �� �۾���
public class GameSetting		// monobehavir ������
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	// �̰Ÿ� static �տ� �ٿ��ָ� ���� ������ �� ȣ�������.
	// �׷��� ���� �����ϸ� �̱��� ������ �ϳ��� ������ ����.

	private static void Init()
	{
		// ���� �����ϱ� �� �ʿ��� ������
		if (GameManager.Instance == null)   // �̱����� �� ���� �� �������.
		{
			GameObject gameManager = new GameObject() { name = "GameManager" };
			gameManager.AddComponent<GameManager>();
		}
	}
}
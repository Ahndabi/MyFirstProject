using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager2 : MonoBehaviour
{
	[SerializeField] private int shootingCount;     // �� �� �� ��Ҵ��� ī��Ʈ
	public UnityAction<int> onshooted;   // ���� ��� ���� �̺�Ʈ ȿ��

	public void AddShootingCount(int count)		// �� ������ ���� �����ϴ� �Լ�
	{
		shootingCount += count;        // �����ͺ��� ������ =������ �ƴ϶� �����ִ� �������!!
		onshooted?.Invoke(shootingCount);
	}

	// GameManager�� ���� �ִ� ��ũ��Ʈ���� �ǽ��κ� �߰��߽��ϴ�
}

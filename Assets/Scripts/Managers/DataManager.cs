using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// 플레이어 레벨, 스텟 등

	// 탱크가 총 몇발의 총을 쏘았는지를 보자
	[SerializeField] private int shootCount;

	public UnityAction<int> OnShootChanged;

	public void AddShootCount(int count)
	{
		shootCount += count;		// 데이터변조 때문에 =대입이 아니라 더해주는 방식으로!!
		OnShootChanged?.Invoke(shootCount);
	}
}
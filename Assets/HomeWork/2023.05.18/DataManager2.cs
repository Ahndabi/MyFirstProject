using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager2 : MonoBehaviour
{
	[SerializeField] private int shootingCount;     // 총 몇 발 쏘았는지 카운트
	public UnityAction<int> onshooted;   // 총을 쏘는 것의 이벤트 효과

	public void AddShootingCount(int count)		// 쏠 때마다 개수 증가하는 함수
	{
		shootingCount += count;        // 데이터변조 때문에 =대입이 아니라 더해주는 방식으로!!
		onshooted?.Invoke(shootingCount);
	}

	// GameManager는 원래 있던 스크립트에서 실습부분 추가했습니다
}

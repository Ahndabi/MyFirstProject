using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
	//************************코루틴 완전 중요***********************************

	/************************************************************************
	 * 코루틴 (Coroutine)
	 * 
	 * 작업을 다수의 프레임에 분산할 수 있는 비동기식 작업(안보고 있는 상황에서 알아서 하게 함)
	 * 반복가능한 작업을 분산하여 진행하며, 실행을 일시정지하고 중단한 부분부터 다시시작할 수 있음
	 * 단, 코루틴은 스레드가 아니며 코루틴의 작업은 여전히 메인 스레드에서 실행  ***이거 중요!***
	 ************************************************************************/
	// 같이 흘러가는 루틴
	// Update말고 따로 작업시키는 것을 만들고 싶다? 그게 coroutine이야
	// 메인에서 분산해서 쓰는 거임.

	// Update에서 총알을 쏘는 기능을 구현하면, 매~~번마다 총알 쏠 수 있는지 확인하겠지.
	// 근데 coroutine에서 따로 총알을 쏘는 기능을 구현하면 Update랑 별개로 작업함

	// <코루틴 진행>
	// 반복가능한 작업을 StartCorouine을 통해 실행

	IEnumerator SubRoutine()    // 코루틴을 돌릴 수 있는 루틴
	{
		for (int i = 0; i < 10; i++)
		{
			Debug.Log($"{i}초 지남");
			yield return new WaitForSeconds(1f);    // 이 자리에서 1초 기다림
													// yield는 바로 반환하지 않고 잠깐 기다렸다가 반환해줄 수 있음
		}
	}

	private Coroutine routine;
	private void CoroutineStart()
	{   // StartCoroutine의 반환형은 Coroutine임
		routine = StartCoroutine(SubRoutine());
	}


	// 코루틴을 시작했는데 중간에 끝내고 싶을 땐?


	// <코루틴 종료>
	// StopCoroutine을 통해 진행 중인 코루틴 종료
	// StopAllCoroutine을 통해 진행 중인 모든 코루틴 종료
	// 반복가능한 작업이 모두 완료되었을 경우 자동 종료
	// 코루틴을 진행시킨 스크립트가 비활성화된 경우 자동 종료

	private void CoroutineStop()
	{
		StopCoroutine(routine);    // 지정한 코루틴 종료
		StopAllCoroutines();       // 모든 코루틴 종료 (진행중인 모든 코루틴 종료) (이 모노비헤비어에 있는 코루틴 종료)
	}

	// <코루틴 시간 지연>
	// 코루틴은 시간 지연을 정의하여 반복가능한 작업의 진행 타이밍을 지정할 수 있음
	IEnumerator CoRoutineWait()
	{
		yield return new WaitForSeconds(1);     // n초간 시간지연
		yield return null;                      // 시간지연 없음 (1 프레임)
	}
}

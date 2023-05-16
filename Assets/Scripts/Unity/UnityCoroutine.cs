using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
	//************************�ڷ�ƾ ���� �߿�***********************************

	/************************************************************************
	 * �ڷ�ƾ (Coroutine)
	 * 
	 * �۾��� �ټ��� �����ӿ� �л��� �� �ִ� �񵿱�� �۾�(�Ⱥ��� �ִ� ��Ȳ���� �˾Ƽ� �ϰ� ��)
	 * �ݺ������� �۾��� �л��Ͽ� �����ϸ�, ������ �Ͻ������ϰ� �ߴ��� �κк��� �ٽý����� �� ����
	 * ��, �ڷ�ƾ�� �����尡 �ƴϸ� �ڷ�ƾ�� �۾��� ������ ���� �����忡�� ����  ***�̰� �߿�!***
	 ************************************************************************/
	// ���� �귯���� ��ƾ
	// Update���� ���� �۾���Ű�� ���� ����� �ʹ�? �װ� coroutine�̾�
	// ���ο��� �л��ؼ� ���� ����.

	// Update���� �Ѿ��� ��� ����� �����ϸ�, ��~~������ �Ѿ� �� �� �ִ��� Ȯ���ϰ���.
	// �ٵ� coroutine���� ���� �Ѿ��� ��� ����� �����ϸ� Update�� ������ �۾���

	// <�ڷ�ƾ ����>
	// �ݺ������� �۾��� StartCorouine�� ���� ����

	IEnumerator SubRoutine()    // �ڷ�ƾ�� ���� �� �ִ� ��ƾ
	{
		for (int i = 0; i < 10; i++)
		{
			Debug.Log($"{i}�� ����");
			yield return new WaitForSeconds(1f);    // �� �ڸ����� 1�� ��ٸ�
													// yield�� �ٷ� ��ȯ���� �ʰ� ��� ��ٷȴٰ� ��ȯ���� �� ����
		}
	}

	private Coroutine routine;
	private void CoroutineStart()
	{   // StartCoroutine�� ��ȯ���� Coroutine��
		routine = StartCoroutine(SubRoutine());
	}


	// �ڷ�ƾ�� �����ߴµ� �߰��� ������ ���� ��?


	// <�ڷ�ƾ ����>
	// StopCoroutine�� ���� ���� ���� �ڷ�ƾ ����
	// StopAllCoroutine�� ���� ���� ���� ��� �ڷ�ƾ ����
	// �ݺ������� �۾��� ��� �Ϸ�Ǿ��� ��� �ڵ� ����
	// �ڷ�ƾ�� �����Ų ��ũ��Ʈ�� ��Ȱ��ȭ�� ��� �ڵ� ����

	private void CoroutineStop()
	{
		StopCoroutine(routine);    // ������ �ڷ�ƾ ����
		StopAllCoroutines();       // ��� �ڷ�ƾ ���� (�������� ��� �ڷ�ƾ ����) (�� ������� �ִ� �ڷ�ƾ ����)
	}

	// <�ڷ�ƾ �ð� ����>
	// �ڷ�ƾ�� �ð� ������ �����Ͽ� �ݺ������� �۾��� ���� Ÿ�̹��� ������ �� ����
	IEnumerator CoRoutineWait()
	{
		yield return new WaitForSeconds(1);     // n�ʰ� �ð�����
		yield return null;                      // �ð����� ���� (1 ������)
	}
}

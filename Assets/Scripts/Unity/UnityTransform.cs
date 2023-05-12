using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{
	/************************************************************************
	 * Ʈ������ (Transform)
	 * 
	 * ���ӿ�����Ʈ�� ��ġ, ȸ��, ũ�⸦ �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �θ�-�ڽ� ���¸� �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �ݵ�� �ϳ��� Ʈ������ ������Ʈ�� ������ ������ �߰� & ������ �� ����
	 ************************************************************************/

	// <Quarternion & Euler>
	// Quarternion	: ����Ƽ�� ���ӿ�����Ʈ�� 3���� ������ �����ϰ� �̸� ���⿡�� �ٸ� ���������� ��� ȸ������ ����
	//				  �������� ȸ������ ������ ������ �߻����� ����
	// EulerAngle	: 3���� �������� ���������� ȸ����Ű�� ���
	//				  ������������ ������ ������ �߻��Ͽ� ȸ���� ��ġ�� ���� ���� �� ����
	// ������		: ���� �������� ������Ʈ�� �� ȸ�� ���� ��ġ�� ����
	// �̰� �����Ϸ����� ����. �׳� ������ �����̶�� �� �ִ�! �׷��� ������ Quarternion ���� ȸ���� �Ѵ�.

	// Quarternion�� ���� ȸ�������� ����ϴ� ���� ���������� �ʰ� �����ϱ� �����
	// ������ ��� ���ʹϾ� -> ���Ϸ����� -> �������� -> ������Ϸ����� -> ������ʹϾ� �� ���� ������ ��� ���ʹϾ��� �����

	private void Rotation()
	{
		// Ʈ�������� ȸ������ Euler���� ǥ���� �ƴ� Quaternion�� �����
		transform.rotation = Quaternion.identity;

		// Euler������ Quaternion���� ��ȯ
		transform.rotation = Quaternion.Euler(0, 90, 0);
	}

	void TranslateMove()
	{
		transform.position = new Vector3(10, 10, 10);   // ��ġ �̵�
		transform.rotation = Quaternion.Euler(0, 0, 0);
		// rotation�� Quaternion�� ��� (Quaternion���� Euler�� �ٲ�)
		transform.localScale = new Vector3(3, 3, 3);	// ũ�� �ٲٱ�
	}

	private void Move()
	{
	}
}

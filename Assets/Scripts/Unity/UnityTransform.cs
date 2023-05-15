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

	// x, y, z������ ���ư��� �̷� �Ŵ� Euler. �츮�� Euler�� ���� ����
	// �ٸ� ������ Quarternion�� ���µ�, �� ������ ������ ������

	// Quarternion�� ���� ȸ�������� ����ϴ� ���� ���������� �ʰ� �����ϱ� �����
	// ������ ��� ���ʹϾ� -> ���Ϸ����� -> �������� -> ������Ϸ����� -> ������ʹϾ� �� ���� ������ ��� ���ʹϾ��� �����
	// �����Ϸ� �������� �׳� Euler ���ָ� ��. �ٵ�, Euler�� ���ٰ� Quarternion�� ���� ��, Quaternion.Euler�� ��

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
		// To eulerAngles �� �� ����
		transform.localScale = new Vector3(3, 3, 3);	// ũ�� �ٲٱ�
	}



	// <Ʈ������ �θ�-�ڽ� ����>
	// Ʈ�������� �θ� Ʈ�������� ���� �� ����
	// �θ� Ʈ�������� �ִ� ��� �θ� Ʈ�������� ��ġ, ȸ��, ũ�� ������ ���� �����
	// �̸� �̿��Ͽ� ������ ������ �����ϴµ� ������ (ex. ���� �����̸�, �հ����� ���� ������)
	// ���̾��Ű â �󿡼� �巡�� & ����� ���� �θ�-�ڽ� ���¸� ������ �� ����
	// �θ��� Ʈ�������� �ٲ�� �ڽĵ� ���� �ٲ� �ʿ䰡 ����
	void TransformParent()
	{
		GameObject newGameObject = new GameObject() { name = "NewGameObject" };

		// �θ�� �ϳ��� ���� �� �־ transform.parent�� ������ �� �ִ�.

		// �θ� ����
		transform.parent = newGameObject.transform;

		// �θ� ���������� Ʈ������
		// transform.localPosition	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
		// transform.localRotation	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
		// transform.localScale		: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��


		// �θ� ����
		transform.parent = null;

		// ���带 ���������� Ʈ������
		// transform.localPosition == transform.position	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ��ġ
		// transform.localRotation == transform.rotation	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ȸ��
		// transform.localScale								: �θ�Ʈ�������� ���� ��� ���带 �������� �� ũ��
	}
}

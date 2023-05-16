using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCollsion : MonoBehaviour
{
	/************************************************************************
	 * �浹ü
	 * 
	 * ������ �浹�� ���� ���ӿ�����Ʈ�� ����� ����
	 * ���ӿ�����Ʈ�� ǥ���� �޽ÿ� �Ȱ��� �ʿ�� ����
	 * �浹ü�� �浹��Ȳ�� ���� ��� ����Ƽ �浹 �޽����� �޾� ��Ȳ�� Ȯ��
	 * �����ִ� ���� �Ǵ��ϴ� ��
	 ************************************************************************/
	// GameObject�� rigidbody�� �ִ� ���¿��� �浹�� ������ �з�����. (�ܺο� ���� ������ �����и�)
	// ���� �浹ü : rigidbody ���� �� �ڸ��� ��� ���������� ���� (ex. �ǹ�, ��)
	// ���� �浹ü������ �浹 ������ X (���� �浹�� �� ��)
	// ������ٵ� �ݶ��̴������� �浹��
	// Rigidbody - isKenematic �� rigidbody�� ������ �и��� ���� ���� ��

	// <����Ƽ �浹 �޽���>
	private void OnCollisionEnter(Collision collision)
	{
		// �浹�� �������� �� �߻�
		Debug.Log("OnCollisionEnter");
	}

	private void OnCollisionStay(Collision collision)
	{
		// ��� �����Ǿ� ���� �� (�浹 ���� ��)
		Debug.Log("OnCollisionStay");
	}

	private void OnCollisionExit(Collision collision)
	{
		// ������� �� (�浹 ������ ��)
		Debug.Log("OnCollisionExit");
	}


	/************************************************************************
	 * Ʈ���� �浹ü
	 * 
	 * �ϳ��� �浹ü�� �浹�� ����Ű�� �ʰ� �ٸ� �浹ü�� ������ ���� ���� ����
	 * Ʈ���Ű� ��ħ��Ȳ�� ���� ��� ����Ƽ Ʈ���� �޽����� �޾� ��Ȳ�� Ȯ��
	 * �浹�� �о�� �� ����. ��ħ ���θ� �Ǵ�! (ex. ������ ����, ������ �����ߴ� ��)
	 ************************************************************************/
	// Collider - is Trigger üũ�ϸ� ��
	// ���� Ʈ���� (�������� �ʴ� Ʈ����)

	// <����Ƽ Ʈ���� �޽���>
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter");
	}

	private void OnTriggerStay(Collider other)
	{
		Debug.Log("OnTriggerStay");
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("OnTriggerExit");
	}

	// <���̾��� �浹 ����>
	// ���ӿ�����Ʈ�� ���̾ Ȱ���Ͽ� �浹ü���� �浹���� ���θ� ���� ����
	// edit -> ProjectSettings -> Physics ���� ���� ����


	// <�浹ü ����>
	// (1) ���� �浹ü (Static Collider)
	// Rigidbody�� ���� �浹ü, �ܺο� ���� �������� ����
	// ����� �������� �ʴ� ����, ������ҿ� �ַ� ���

	// (2) ������ٵ� �浹ü (Rigidbody Collider)
	// Rigidbody�� �ִ� �浹ü, �ܺο� ���� �޾� ������
	// �浹�� �� ������ ������ ����ϴ� ���� �� ���� ���� ���Ǵ� �浹ü�� ���

	// (3) Ű�׸�ƽ �浹ü (Kinematic Collider)
	// Kinematic Rigidbody�� �ִ� �浹ü, �ܺ��� ���� �������� ����
	// ���������� �ܺ� ��ݿ��� �и��� �ʴ� ��ü(�о�� ��ֹ�, �̴��̹� ��)�� �� ���
	// kinematic ���¸� Ȱ��ȭ/��Ȱ��ȭ �Ͽ� ������ ���θ� ������ ��� ���


	// <�浹ü ��ȣ�ۿ� ��Ʈ����>
	// ���ǻ� �����浹ü(SC), ������ٵ��浹ü(RC), Ű�׸�ƽ�浹ü(KC)�� ǥ��
	// ���ǻ� ����Ʈ����(ST), ������ٵ�Ʈ����(RT), Ű�׸�ƽƮ����(KT)�� ǥ��

	// �浹�� �浹 �޽����� ����
	//		SC	RC	KC
	// SC		 O	
	// RC	 O	 O	 O
	// KC		 O	

	// �浹�� Ʈ���� �޽����� ����
	//		SC	RC	KC	ST	RT	KT
	// SC					 O	 O
	// RC				 O	 O	 O
	// KC				 O	 O	 O
	// ST		 O	 O		 O	 O
	// RT	 O	 O	 O	 O	 O	 O
	// KT	 O	 O	 O	 O	 O	 O
}



// Ctrl Shift F �ϸ� �ٶ󺸴� ������ �ٷ� ��ü �ݿ���ų �� ����
// 
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
	public GameObject player;
	public AudioSource audiosource;
	// ������Ʈ�� ���ӿ�����Ʈ�� ������ �� �ִ� ���. gameObject�� ���ָ� ��!
	// gameObject : �� ������Ʈ�� �پ��ִ� gameObject�� �ҷ����ش�.
	// ������Ʈ�� gameObject�� null�̸� �ȵ�. null�̸� ���ʿ� �� ������Ʈ�� ���������̴�.
	private void Start()
	{
		GameObjectBasic();
	}
	public void GameObjectBasic()
	{
		// <���ӿ�����Ʈ ����>
		// ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� gameObject �Ӽ��� �̿��Ͽ� ���ٰ���
		// gameObject;					  // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ
		// gameObject.name;               // ���ӿ�����Ʈ�� �̸� ����
		// gameObject.activeSelf;         // ���ӿ�����Ʈ�� Ȱ��ȭ ���� ����
		// gameObject.tag;                // ���ӿ�����Ʈ�� �±� ����
		// gameObject.layer;              // ���ӿ�����Ʈ�� ���̾� ����

		player = GameObject.Find("Player");		// �̸����� ã��
		// ���� �̸��� ���� ������Ʈ�� ���� ���� ���, ���� ���� ã�� ������Ʈ�� ��. (�׷��� ���� ���� ���X)
		player = GameObject.FindGameObjectWithTag("Player");    // �±׷� ã��
		// �׷��� �̷��� �±׷� ã�� �� �� ����
		// ���� �±װ� ���� �� �ִ� ��� FindGameObjectsWithTag�� �� s����(�׷��� �� �迭��)

		// <���ӿ�����Ʈ ����>
		GameObject newobject = new GameObject();

		// <���ӿ�����Ʈ ����>
		Destroy(newobject);		// (newobject, 5f) �̷��� 5�� �ڿ� ������. ��������
	}

	public void ComponentBasic()
	{   // ������Ʈ�� �⺻�Լ�
		// <���ӿ�����Ʈ �� ������Ʈ ����>
		audiosource = GetComponent<AudioSource>();
		// ���� ������Ʈ�� �ִ� ������Ʈ(�� ���� ������Ʈ)�� ã�´�.
		// ������Ʈ���� GetComponent�� ����� ��� �����Ǿ� �ִ� ���ӿ�����Ʈ�� �������� ����
		audiosource = gameObject.GetComponent<AudioSource>(); // ���ӿ�����Ʈ�� ������Ʈ ����
		GetComponents<AudioSource>();	// ���� �� ã�� ���. GetComponents (��ȯ�� �迭��)

		// ���� �ڽ� ������Ʈ�� ������Ʈ�� ã��ʹ�? (�� ����)
		GetComponentInChildren<AudioSource>();  // �ڽ� ���ӿ�����Ʈ ���� ������Ʈ ����
		GetComponentsInChildren<AudioSource>(); // �ڽĿ�����Ʈ ���� ���� ������Ʈ�� ����(���־���)

		// �θ�� �ڽĺ��� �� ����. �� �� ���δ�
		gameObject.GetComponentInParent<AudioSource>();      // �θ� ���ӿ�����Ʈ ���� ������Ʈ ����
		gameObject.GetComponentsInParent<AudioSource>();    // �θ� ���ӿ�����Ʈ ���� ������Ʈ�� ����

		// <������Ʈ Ž��>		 �ð��� ���� �ɸ�..
		FindObjectOfType<AudioSource>();	// �� ���� ������Ʈ Ž��
		FindObjectsOfType<AudioSource>();   // �� ���� ��� ������Ʈ Ž��
											// �� �����Ӹ��� ã�� ��� ����ϴ� ���� ����X. �� �� ã�Ƴ��� ��--�̰� ����!!

		// <������Ʈ �߰�>
		// Rigidbody rigid = new Rigidbody();
		// ������Ʈ�� ������Ʈ�� �� �پ� ������ �����ϳ� �ǹ̾���, ������Ʈ�� ���ӿ�����Ʈ�� �����Ǿ� �����Կ� �ǹ̰� ����
		AudioSource s = gameObject.AddComponent<AudioSource>();     // ���ӿ�����Ʈ�� ������Ʈ �߰�

		// <������Ʈ ����>
		Destroy(GetComponent<Collider>());
	}
}

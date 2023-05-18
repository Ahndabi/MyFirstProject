using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootCountView : MonoBehaviour
{
	// �������(view).	(MVC ������ ����)
	// ���⿡ �����ͳ� ��Ʈ�ѷ��� ����X

	// int shootCount;		// �̰� �������ڰ�!! UI�� �����͸� ����X ���� UI�뵵�θ� ���� ����
	private TMP_Text textView;      // TMP_Text = Text_MeshPro

	private void Awake()
	{
		textView = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		GameManager.Data.OnShootChanged += ChangeText;
	}

	private void OnDisable()
	{
		GameManager.Data.OnShootChanged -= ChangeText;	}


	private void ChangeText(int count)		// text���� text�� �ٲ��ִ� �Լ�
	{
		textView.text = count.ToString();
	}

	// AddShootCount(int count) {}	// �̷� ���������̳� ���굵 ��������. ���� UI ������ 
}

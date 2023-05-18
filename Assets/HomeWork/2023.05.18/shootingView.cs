using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shootingView : MonoBehaviour
{
	public TMP_Text textView;      // TMP_Text = Text_MeshPro

	private void Awake()
	{
		textView = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		GameManager.Data2.onshooted += ChangeText;
	}

	private void OnDisable()
	{
		GameManager.Data2.onshooted -= ChangeText;
	}

	private void ChangeText(int count)      // text���� text�� �ٲ��ִ� �Լ�
	{
		textView.text = count.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootCountView : MonoBehaviour
{
	// 출력전용(view).	(MVC 패턴의 예시)
	// 여기에 데이터나 컨트롤러를 구현X

	// int shootCount;		// 이걸 하지말자고!! UI에 데이터를 포함X 여긴 UI용도로만 쓰는 곳임
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


	private void ChangeText(int count)		// text뷰의 text를 바꿔주는 함수
	{
		textView.text = count.ToString();
	}

	// AddShootCount(int count) {}	// 이런 로직구현이나 연산도 하지말자. 여긴 UI 구현만 
}

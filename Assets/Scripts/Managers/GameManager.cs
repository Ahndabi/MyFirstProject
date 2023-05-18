using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	private static DataManager dataManager;		// DataManager�� �̱������� ���!
	static DataManager2 dataManager2;	// �ǽ�
	public static GameManager Instance { get { return instance; } }		// �ν��Ͻ� ������Ƽ
	public static DataManager Data { get { return dataManager; } }
	public static DataManager2 Data2 { get { return dataManager2; } }	// �ǽ�

	private void Awake()
	{
		if (instance != null)	
		{
			Destroy(this);	// instance�� �̹� �־��� �� this(������Ʈ)�� ���� (this�� �� ������Ʈ�ϱ� �� ��ũ��Ʈ��)
			return;
		}
		instance = this;

		// ����Ƽ�� ������Ʈ �����̶� ���� ��ȯ�� ���� �̰� ����������ߵ� - �׷��� DontDestroyOnLoad�� ���ִ°ž�. �ٸ���������  �������� �ʵ���
		// (�������� ��� 100�̾��µ� ���� ���� ��� ������? ���̾ȵ�)
		DontDestroyOnLoad(this);	// ���� �Դٰ��� �ص� this�� �� ������!
		instance = this;
		InitManager();

		InitManager2();
		// �ٵ� ���� �ƿ� �� �����? �ƿ� �� �������� ���� ���۵Ǹ� �ڵ����� ���ӸŴ��� �̱��� �ϳ��� �����������.
	} 

	private void OnDestroy()
	{
		if (instance == this)
			instance = null;
	}
	
	void InitManager()		// DataManager�� �ʱ�ȭ�� ���ִ� �۾�!
	{
		// DataManager init
		GameObject dataObj = new GameObject() { name = "DataManager" };
		dataObj.transform.SetParent(transform);
		dataManager = dataObj.AddComponent<DataManager>();
	}
	// ���� �����ϸ� DataManager�� GameManager�� �����ڽ����� ���ܳ�



	//**************�ǽ�*************
	void InitManager2()
	{
		GameObject dataOb = new GameObject() { name = "DataManager2" };
		dataOb.transform.SetParent(transform);
		dataManager2 = dataOb.AddComponent<DataManager2>();
	}
}
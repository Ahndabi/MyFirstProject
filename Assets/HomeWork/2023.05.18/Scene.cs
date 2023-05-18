using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
	public void ChangeScene()
	{
		SceneManager.LoadScene("Test");
	}


	public void ChangeScene2()
	{
		SceneManager.LoadScene("FirstScene");
	}
}

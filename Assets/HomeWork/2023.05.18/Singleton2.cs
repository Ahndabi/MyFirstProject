using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton2 : MonoBehaviour
{
	static Singleton2 instance;
	public static Singleton2 Instance
	{
		get
		{
			if (instance == null)
				instance = new Singleton2();
			return instance;
		}
	}
	Singleton2() { }
}
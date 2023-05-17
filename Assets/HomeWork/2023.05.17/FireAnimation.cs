using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireAnimation : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject bulletPoint;
	[SerializeField] Animator animator;

	public void OnFire(InputValue value)
	{
		Fire();
	}

	public void Fire()
	{
		Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
		animator.SetTrigger("Fire");
		Destroy(bullet, 3f);
	}
}

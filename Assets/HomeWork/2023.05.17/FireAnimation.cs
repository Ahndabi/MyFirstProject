using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireAnimation : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject bulletPoint;
	[SerializeField] Animator animator;
	[SerializeField] float moveSpeed;
	Vector3 dir;
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

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

	void OnMove(InputValue value)
	{
		dir.x = value.Get<Vector2>().x;
		dir.z = value.Get<Vector2>().y;
		Move();
	}

	void Move()
	{
		rb.AddForce(dir * moveSpeed * Time.deltaTime, ForceMode.Force);
	}
}

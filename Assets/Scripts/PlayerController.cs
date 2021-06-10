using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 5f;
	private Rigidbody body;
	public Material mat;

	private void Start()
	{
		body = GetComponent<Rigidbody>();
		mat.color = Color.red;
	}

	Vector3 direction;
	public float jumpForce = 20;
	private bool jump = false;

	private void Update()
	{
		direction = Vector3.zero;
		if(Input.touchCount == 1)
		{
			Touch touch = Input.touches[0];
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			if(Physics.Raycast(ray, out hit))
			{
				if(hit.transform.CompareTag("Player") && jump)
				{
					jump = false;
					body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				}
			}
			else if(touch.position.x < Screen.width/2)
			{
				direction = Vector3.left;
			}
			else if(touch.position.x > Screen.width/2)
			{
				direction = Vector3.right;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			direction = Vector3.left;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			direction = Vector3.right;
		}
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit) && jump)
			{
				if (hit.transform.CompareTag("Player"))
				{
					jump = false;
					body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				}
			}
		}
	}

	private void FixedUpdate()
	{
			body.AddForce(direction * speed, ForceMode.Acceleration);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
		{
			jump = true;
		}
	}
}

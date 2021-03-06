using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 5;
	public float gravity = -5;

	float velocityY = 0;
	public Timer timer;

	CharacterController controller;
	Animator               anim;
	bool					start;
	public ScriptabledObject	data;
	private bool				end;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		end = false;
		start = false;
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
		controller.enabled = false;
	}

	public void Starting()
	{
		anim.Play("Sit");
		for (int i = 0; i < data.instruments.Length; i++)
			data.instruments[i] = false;
		controller.enabled = true;
		start = true;
		timer.StartTimer();
		DeathTimer.win = false;
		DeathTimer.mainStart = true;
		PlayerPrefs.SetInt("Death", 0);
		PlayerPrefs.SetInt("Beat", 0);
	}

	void Update()
	{
		if (!end)
		{
			if (start)
			{
				if (DeathTimer.death == false)
				{
					velocityY += gravity * Time.deltaTime;

					Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
					input = input.normalized;

					Vector3 temp = Vector3.zero;
					if (input.z == 1)
					{
						temp += transform.forward;
						anim.Play("Walk");
					}
					else if (input.z == -1)
					{
						temp += transform.forward * -1;
						anim.Play("Back");
					}
					else if (input.x == 1)
					{
						temp += transform.right;
						anim.Play("Walk");
					}
					else if (input.x == -1)
					{
						temp += transform.right * -1;
						anim.Play("Walk");
					}
					Vector3 velocity = temp * speed;
					velocity.y = velocityY;
					if (Input.GetKeyDown(KeyCode.LeftShift))
					{
						speed = 10;
						anim.speed = 2;
					}
					if (Input.GetKeyUp(KeyCode.LeftShift))
					{
						speed = 5;
						anim.speed = 1;
					}

					if (PlayerPrefs.GetInt("Beat") == 1)
						anim.Play("Beat");
					else
					{
						if (input.z == 0 && input.x == 0)
						{
							velocityY = 0;
							anim.Play("Idle");
						}
					}
					controller.Move(velocity * Time.deltaTime);
				}
				else
				{
					int random = Random.Range(0, 3);
					Instantiate(data.Death[random], transform.position, transform.rotation);
					anim.Play("Death");
					end = true;
				}
			}
		}
	}
	// speed is the rate at which the object will rotate
	public float speed_look;
 
	void FixedUpdate () 
	{
		if (start)
		{
			if (PlayerPrefs.GetInt("Beat") == 0 && DeathTimer.death == false)
			{
				// Generate a plane that intersects the transform's position with an upwards normal.
				Plane playerPlane = new Plane(Vector3.up, transform.position);
		
				// Generate a ray from the cursor position
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
				// Determine the point where the cursor ray intersects the plane.
				// This will be the point that the object must look towards to be looking at the mouse.
				// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
				//   then find the point along that ray that meets that distance.  This will be the point
				//   to look at.
				float hitdist = 0.0f;
				// If the ray is parallel to the plane, Raycast will return false.
				if (playerPlane.Raycast (ray, out hitdist)) 
				{
					// Get the point along the ray that hits the calculated distance.
					Vector3 targetPoint = ray.GetPoint(hitdist);
		
					// Determine the target rotation.  This is the rotation if the transform looks at the target point.
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
		
					// Smoothly rotate towards the target point.
					transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed_look * Time.deltaTime);
				}
			}
		}
    }
}
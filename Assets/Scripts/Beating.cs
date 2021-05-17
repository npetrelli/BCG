using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beating : MonoBehaviour
{
	public	ScriptabledObject	data;
	public  GameObject      Person;
	public  int             time;
	float                   timeCurrent;
	float                   timeAtButtonDown;
	float                   timeAtButtonUp;
	float                   timeButtonHeld = 0;
	public MiniTimer        miniTimer;
	public	Renderer		renderer;
	public	GameObject			click;
	[HideInInspector]public	int   id;
	public GameObject[]		walls;
	void OnEnable()
    {
        int rand = Random.Range(0,3);
		renderer.material = data.material[rand];
		id = rand;
    }

	private void OnMouseDown()
	{
		float dist = Vector3.Distance(Person.transform.position, transform.position);
		Debug.Log(dist);
		if (dist < 3 && data.instruments[id])
		{
		   PlayerPrefs.SetInt("Beat", 1);
		   miniTimer.pause = false;
		   miniTimer.Timer();
		}
		timeAtButtonDown = timeCurrent;
	}

	private void OnMouseUp()
	{
		if ( PlayerPrefs.GetInt("Beat") == 1)
		{
			timeAtButtonUp = timeCurrent;
			timeButtonHeld = (timeAtButtonUp - timeAtButtonDown);
			if (timeButtonHeld < time)
			{
				miniTimer.pause = true;
				miniTimer.fillImage.fillAmount = 0;
				PlayerPrefs.SetInt("Beat", 0);
			}
		}
	}
	private void OnMouseEnter()
    {
		if (data.instruments[id])
        	click.gameObject.SetActive(true);
    }

	private void OnMouseExit()
	{
		click.gameObject.SetActive(false);
	}

	void Update ()
	{
		timeCurrent = Time.fixedTime;
	}
}

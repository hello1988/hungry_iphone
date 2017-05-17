using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchWifi : MonoBehaviour 
{
	[SerializeField]
	private GameObject wifi;

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		tweenAlpha ani = wifi.GetComponent<tweenAlpha> ();
		ani.play ();

	}

}

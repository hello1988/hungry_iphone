using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class movieCtrl : MonoBehaviour 
{
	[SerializeField]
	private MovieTexture navigationMov;
	// Use this for initialization
	void Start () {

		Renderer r = GetComponent<Renderer> ();
		r.material.mainTexture = navigationMov as MovieTexture;

		navigationMov.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable()
	{
	}

	public void play()
	{
		navigationMov.Play ();
	}

	public void stop()
	{
		navigationMov.Stop ();
	}
}

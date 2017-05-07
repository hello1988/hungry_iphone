using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberCtrl : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] numberList;
	[SerializeField]
	private Image numberImg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setNumber(int num)
	{
		int index = Math.Max (Math.Min( num, 9), 0);
		numberImg.sprite = numberList [index];

		gameObject.SetActive (index > 0);

	}
}

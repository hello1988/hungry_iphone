using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reportCtrl : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] faceList;
	[SerializeField]
	private Sprite[] date1List;
	[SerializeField]
	private Sprite[] date2List;
	[SerializeField]
	private Image[] imageList;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showReport( int index )
	{
		imageList [0].sprite = faceList [index];
		imageList [1].sprite = date1List [index];
		imageList [2].sprite = date2List [index];
	}
}

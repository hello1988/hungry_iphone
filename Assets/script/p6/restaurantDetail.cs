using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restaurantDetail : MonoBehaviour {

	[SerializeField]
	private Sprite[] restaurantLargeSprite;
	[SerializeField]
	private Image restaurantImg;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setInfo( int restaurantID )
	{
		int spriteIndex = restaurantID - 1;

		restaurantImg.sprite = restaurantLargeSprite [spriteIndex];
	}
}

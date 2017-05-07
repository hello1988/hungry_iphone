using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restaurantCtrl : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] restaurantSprite;
	[SerializeField]
	private scrollCtrl restaurantScroll;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		restaurantScroll.reset ();

		for( int index = 0;index < restaurantSprite.Length;index++ )
		{
			int restaurantID = index + 1;
			GameObject newObj = restaurantScroll.addItem ();

			clickRestaurant click = newObj.GetComponent<clickRestaurant> ();
			click.setInfo (restaurantID, restaurantSprite [index]);
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickRestaurant : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	private page6Ctrl target;

	private int restaurantID = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setInfo( int ID, Sprite sprite )
	{
		Image img = GetComponent<Image> ();
		img.sprite = sprite;

		restaurantID = ID;
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		target.showDetailUI (restaurantID);
	}
}

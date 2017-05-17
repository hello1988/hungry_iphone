using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class passEvent : MonoBehaviour , IPointerUpHandler, IPointerDownHandler, IDragHandler
{
	[SerializeField]
	private GameObject[] targetList;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void OnPointerDown (PointerEventData eventData)
	{
		passToTarget ("OnPointerDown", eventData);
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		passToTarget ("OnPointerUp", eventData);
	}

	public void OnDrag (PointerEventData eventData)
	{
		passToTarget ("OnDrag", eventData);
	}

	private void passToTarget ( string functionName, PointerEventData eventData )
	{
		foreach (GameObject obj in targetList) 
		{
			obj.SendMessage (functionName, eventData, SendMessageOptions.DontRequireReceiver);
		}
	}
}

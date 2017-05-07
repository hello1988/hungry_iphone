using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragTip : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[SerializeField]
	private int dragDistance = -330;

	private GameObject touchPoint;
	private Vector3 oriPos;
	private Vector3 startPos;
	private Vector3 startDragPos;
	void Awake () 
	{
		touchPoint = new GameObject ("touchPoint");
		touchPoint.transform.SetParent (transform.parent);

		oriPos = transform.localPosition;	
	}

	void Update () {}


	void OnEnable()
	{
		transform.localPosition = oriPos;
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		startPos = touchPoint.transform.localPosition;

		startDragPos = transform.localPosition;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		Vector3 curPos = transform.localPosition;
		float posY = ( curPos.y <= (oriPos.y+dragDistance/3) ) ? (oriPos.y+dragDistance) : oriPos.y;
		transform.localPosition = new Vector3( oriPos.x, posY, oriPos.z );
	}

	public void OnDrag (PointerEventData eventData)
	{
		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 pos = touchPoint.transform.localPosition;

		Vector3 offset = pos - startPos;
		float posY = Math.Min (Math.Max ((startDragPos.y+offset.y), (oriPos.y+dragDistance)), oriPos.y);
		transform.localPosition = new Vector3( oriPos.x, posY, oriPos.z );
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Const;

public class slideDectect : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private Dictionary<DIRECTION, List<slideCallBack>> callBackMap ;
	private GameObject touchPoint;
	private Vector3 startPos;

	void Awake () 
	{
		callBackMap = new Dictionary<DIRECTION, List<slideCallBack>>();

		callBackMap.Add (DIRECTION.UP, new List<slideCallBack> ());
		callBackMap.Add (DIRECTION.RIGHT, new List<slideCallBack> ());
		callBackMap.Add (DIRECTION.DOWN, new List<slideCallBack> ());
		callBackMap.Add (DIRECTION.LEFT, new List<slideCallBack> ());

		touchPoint = new GameObject ("touchPoint");
		touchPoint.transform.SetParent (transform.parent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void registCallBack(DIRECTION dir, slideCallBack callback)
	{
		if (callback == null) {return;}

		callBackMap[dir].Add (callback);
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		startPos = touchPoint.transform.localPosition;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 endpos = touchPoint.transform.localPosition;

		Vector3 offset = endpos - startPos;
		if( offset.x > 0 )
		{
			doCallBack (callBackMap [DIRECTION.RIGHT], Math.Abs (offset.x));
		}
		else if ( offset.x <= 0 )
		{
			doCallBack (callBackMap [DIRECTION.LEFT], Math.Abs (offset.x));
		}

		if( offset.y > 0 )
		{
			doCallBack (callBackMap [DIRECTION.UP], Math.Abs (offset.y));
		}
		else if ( offset.y <= 0 )
		{
			doCallBack (callBackMap [DIRECTION.DOWN], Math.Abs (offset.y));
		}
	}

	private void doCallBack( List<slideCallBack> funcList, float distance )
	{
		for( int index = 0;index < funcList.Count;index++ )
		{
			funcList [index] (distance);
		}
	}
}

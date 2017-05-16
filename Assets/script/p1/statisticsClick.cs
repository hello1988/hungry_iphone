﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class statisticsClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField]
	private mode1Ctrl modeCtrl;

	private GameObject touchPiont;
	private int reportIndex = 0;

	void Awake () 
	{
		touchPiont = new GameObject ("touchPiont");
		touchPiont.transform.SetParent (transform.parent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		touchPiont.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 pos = touchPiont.transform.localPosition;

		// 計算兩者之間角度
		double angle = getAngle( transform.localPosition, pos );

		// -72~145	happy
		if( (angle >= -72) && (angle <= 145) )
		{
			modeCtrl.showReport (0);
		}
		// -72~-129	soso
		else if( (angle < -72) && (angle >= -129) )
		{
			modeCtrl.showReport (1);
		}
		// else bad
		else
		{
			modeCtrl.showReport (2);
		}


	}

	public void OnPointerUp (PointerEventData eventData)
	{
		// modeCtrl.showReport (reportIndex);
	}

	private double getAngle(Vector3 a, Vector3 b)
	{
		if ( a.x == b.x && a.y >= b.y ) return 0;

		b -= a;
		double angle = Math.Acos(-b.y / b.magnitude) * (180 / Math.PI);

		return (b.x < a.x ? -angle : angle);
	}
}

using System;
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
	private Vector3 startPos;

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
		startPos = touchPiont.transform.localPosition;

		// 計算兩者之間角度
		double angle = getAngle( transform.localPosition, startPos );

		// -72~145	happy
		if( (angle >= -72) && (angle <= 145) )
		{
			reportIndex = 0;
		}
		// -72~-129	soso
		else if( (angle < -72) && (angle >= -129) )
		{
			reportIndex = 1;
		}
		// else bad
		else
		{
			reportIndex = 2;
		}

	}

	public void OnPointerUp (PointerEventData eventData)
	{
		touchPiont.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 endPos = touchPiont.transform.localPosition;

		Vector3 offset = endPos - startPos;
		if ((Math.Abs (offset.x) > 10) || (Math.Abs (offset.y) > 10)) 
		{
			return;
		}

		modeCtrl.showReport (reportIndex);
	}

	private double getAngle(Vector3 a, Vector3 b)
	{
		if ( a.x == b.x && a.y >= b.y ) return 0;

		b -= a;
		double angle = Math.Acos(-b.y / b.magnitude) * (180 / Math.PI);

		return (b.x < a.x ? -angle : angle);
	}
}

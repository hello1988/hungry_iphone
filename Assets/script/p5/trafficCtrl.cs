using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Const;

public class trafficCtrl : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] trafficSprite;
	[SerializeField]
	private GameObject trafficImg;
	[SerializeField]
	private GameObject[] dotList;
	[SerializeField]
	private page5Ctrl pageCtrl;

	private TRAFFIC_WAY curTrafficWay = TRAFFIC_WAY.WALK;
	private GameObject touchPoint;
	private Vector3 startPos = Vector3.zero;
	private Vector3 oriPos = Vector3.zero;
	private bool pressing = false;

	void Awake () 
	{
		touchPoint = new GameObject ("touchPoint");
		touchPoint.transform.SetParent (trafficImg.transform.parent);

		oriPos = trafficImg.transform.localPosition;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnEnable() 
	{
		pressing = false;
		setTrafficWay( TRAFFIC_WAY.WALK, false );
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		pressing = true;
		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		startPos = touchPoint.transform.localPosition;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		pressing = false;
		trafficImg.transform.localPosition = oriPos;
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (!pressing) {return;}

		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 pos = touchPoint.transform.localPosition;

		Vector3 offset = new Vector3 (pos.x-startPos.x, 0, 0);
		trafficImg.transform.localPosition = oriPos+offset;

		int totalWay = Enum.GetNames (typeof(TRAFFIC_WAY)).Length;
		int iWay = (int)curTrafficWay;
		if( (offset.x < -100) && (iWay < totalWay-1) )
		{
			pressing = false;
			LeanTween.moveLocalX (trafficImg, -1000, 0.3f).setOnComplete (nextWay);
		}
		else if( (offset.x > 100) && (iWay > 0) )
		{
			pressing = false;
			LeanTween.moveLocalX (trafficImg, 1000, 0.3f).setOnComplete (preWay);
		}
	}

	public void nextWay()
	{
		trafficImg.transform.localPosition = new Vector3 (1000, 0, 0);

		int totalWay = Enum.GetNames (typeof(TRAFFIC_WAY)).Length;
		TRAFFIC_WAY way = (TRAFFIC_WAY)(((int)curTrafficWay+1)%totalWay);
		setTrafficWay (way);
	}

	public void preWay()
	{
		trafficImg.transform.localPosition = new Vector3 (-1000, 0, 0);

		int totalWay = Enum.GetNames (typeof(TRAFFIC_WAY)).Length;
		TRAFFIC_WAY way = (TRAFFIC_WAY)(((int)curTrafficWay+totalWay-1)%totalWay);
		setTrafficWay (way);
	}

	public void onTrafficImgClick()
	{
		DataMgr.Instance.setTrafficWay (curTrafficWay);

		if( curTrafficWay == TRAFFIC_WAY.MRT )
		{
			pageCtrl.showMRTUI();
		}
		else
		{
			pageCtrl.nextPage ();
		}
	}

	private void setTrafficWay( TRAFFIC_WAY way, bool playAni = true )
	{
		// Debug.logger.Log (string.Format("setTrafficWay({0}, {1})",way, playAni));
		if (playAni) 
		{
			LeanTween.moveLocalX (trafficImg, oriPos.x, 0.3f);
		}
		else
		{
			trafficImg.transform.localPosition = oriPos;
		}

		curTrafficWay = way;
		Image img = trafficImg.GetComponent<Image> ();
		img.sprite = trafficSprite [(int)way];

		for(int index = 0;index < dotList.Length;index++)
		{
			float scale = ( (int)way == index ) ? 1.5f:1.0f;

			LeanTween.scale (dotList [index], Vector3.one * scale, 0.3f);
		}
	}
}

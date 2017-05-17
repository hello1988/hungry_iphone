using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Const;

public class trafficCtrl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
	[SerializeField]
	private Sprite[] trafficSprite;
	[SerializeField]
	private GameObject trafficImg;
	[SerializeField]
	private GameObject[] dotList;
	[SerializeField]
	private page5Ctrl pageCtrl;
	[SerializeField]
	private float tweenSec = 0.3f;

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
		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 endPos = touchPoint.transform.localPosition;

		pressing = false;
		trafficImg.transform.localPosition = oriPos;

		if( Math.Abs((endPos-startPos).x) < 10 )
		{
			onTrafficImgClick ();
		}
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
			nextWay();
		}
		else if( (offset.x > 100) && (iWay > 0) )
		{
			pressing = false;
			preWay();
		}
	}

	public void nextWay()
	{
		int totalWay = Enum.GetNames (typeof(TRAFFIC_WAY)).Length;
		int iWay = (int)curTrafficWay;
		if( iWay >= (totalWay-1) ){return ;}

		slideAni ani = trafficImg.GetComponent<slideAni> ();
		ani.makeShadow (oriPos);

		iWay++;
		setTrafficWay ((TRAFFIC_WAY)iWay);

		Vector3 moveDir = new Vector3 ( -800, 0, 0);
		ani.playAni (moveDir, tweenSec);
	}

	public void preWay()
	{
		int iWay = (int)curTrafficWay;
		if( iWay <= 0 ){return ;}

		slideAni ani = trafficImg.GetComponent<slideAni> ();
		ani.makeShadow (oriPos);

		iWay--;
		setTrafficWay ((TRAFFIC_WAY)iWay);

		Vector3 moveDir = new Vector3 ( 800, 0, 0);
		ani.playAni (moveDir, tweenSec);
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
		curTrafficWay = way;
		Image img = trafficImg.GetComponent<Image> ();
		img.sprite = trafficSprite [(int)way];

		for(int index = 0;index < dotList.Length;index++)
		{
			float scale = ( (int)way == index ) ? 1.5f:1.0f;

			LeanTween.scale (dotList [index], Vector3.one * scale, tweenSec);
		}
	}
}

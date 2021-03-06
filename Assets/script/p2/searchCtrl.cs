﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Const;

public class searchCtrl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
	[SerializeField]
	private Sprite[] searchSprite;
	[SerializeField]
	private GameObject searchImg;
	[SerializeField]
	private GameObject[] dotList;
	[SerializeField]
	private page2Ctrl pageCtrl;
	[SerializeField]
	private float tweenSec = 0.3f;

	private Sprite[][] aniSprite;
	private SEARCH_WAY curSearchWay = SEARCH_WAY.WAY1;

	private GameObject touchPoint;
	private Vector3 startPos = Vector3.zero;
	private Vector3 oriPos = Vector3.zero;
	private bool pressing = false;
	void Awake () 
	{
		touchPoint = new GameObject ("touchPoint");
		touchPoint.transform.SetParent (searchImg.transform.parent);

		oriPos = searchImg.transform.localPosition;

		aniSprite = new Sprite[searchSprite.Length/2][];

		for( int index = 0;index < searchSprite.Length;index+=2 )
		{
			int aniIndex = index / 2;
			aniSprite [aniIndex] = new Sprite[2];
			aniSprite [aniIndex][0] = searchSprite[index];
			aniSprite [aniIndex][1] = searchSprite[index+1];
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable() 
	{
		pressing = false;
		setSearchWay( SEARCH_WAY.WAY1, false );
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
		searchImg.transform.localPosition = oriPos;

		if( Math.Abs((endPos-startPos).x) < 10 )
		{
			onSearchImgClick ();
		}
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (!pressing) {return;}

		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 pos = touchPoint.transform.localPosition;

		Vector3 offset = new Vector3 (pos.x-startPos.x, 0, 0);
		searchImg.transform.localPosition = oriPos+offset;

		int totalWay = Enum.GetNames (typeof(SEARCH_WAY)).Length;
		int iWay = (int)curSearchWay;
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
		int totalWay = Enum.GetNames (typeof(SEARCH_WAY)).Length;
		int iWay = (int)curSearchWay;
		if( iWay >= (totalWay-1) )
		{
			searchImg.transform.localPosition = oriPos;
			return ;
		}


		playAniAlpha ani = searchImg.GetComponent<playAniAlpha> ();
		ani.stop ();

		slideAni sAni = searchImg.GetComponent<slideAni> ();
		sAni.makeShadow (oriPos);

		iWay++;
		SEARCH_WAY way = (SEARCH_WAY)iWay;
		setSearchWay (way);

		Vector3 moveDir = new Vector3 ( -800, 0, 0);
		sAni.playAni (moveDir, tweenSec);
	}

	public void preWay()
	{
		int iWay = (int)curSearchWay;
		if( iWay <= 0 )
		{
			searchImg.transform.localPosition = oriPos;
			return ;
		}

		playAniAlpha ani = searchImg.GetComponent<playAniAlpha> ();
		ani.stop ();

		slideAni sAni = searchImg.GetComponent<slideAni> ();
		sAni.makeShadow (oriPos);

		iWay--;
		SEARCH_WAY way = (SEARCH_WAY)iWay;
		setSearchWay (way);

		Vector3 moveDir = new Vector3 ( 800, 0, 0);
		sAni.playAni (moveDir, tweenSec);
	}

	public void onSearchImgClick()
	{
		// Debug.logger.Log (string.Format("onSearchImgClick : {0}",curSearchWay));
		pageCtrl.nextPage (curSearchWay);
	}

	private void setSearchWay( SEARCH_WAY way, bool playAni = true )
	{
		curSearchWay = way;
		playAniAlpha ani = searchImg.GetComponent<playAniAlpha> ();
		ani.setAniList (aniSprite[(int)way]);
		ani.play ();

		for(int index = 0;index < dotList.Length;index++)
		{
			float scale = ( (int)way == index ) ? 1.5f:1.0f;

			LeanTween.scale (dotList [index], Vector3.one * scale, tweenSec);
		}
	}
}

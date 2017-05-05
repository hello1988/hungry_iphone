using System;
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
		pressing = false;
		searchImg.transform.localPosition = oriPos;
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (!pressing) {return;}

		touchPoint.transform.position = UIMgr.Instance.getCurMousePosition ();
		Vector3 pos = touchPoint.transform.localPosition;

		Vector3 offset = new Vector3 (pos.x-startPos.x, 0, 0);
		searchImg.transform.localPosition = oriPos+offset;

		if( offset.x < -100 )
		{
			pressing = false;
			LeanTween.moveLocalX (searchImg, -1000, 0.3f).setOnComplete (nextWay);
		}
		else if( offset.x > 100 )
		{
			pressing = false;
			LeanTween.moveLocalX (searchImg, 1000, 0.3f).setOnComplete (preWay);
		}
	}

	public void nextWay()
	{
		searchImg.transform.localPosition = new Vector3 (1000, 0, 0);
		playAni ani = searchImg.GetComponent<playAni> ();
		ani.stop ();

		int totalWay = Enum.GetNames (typeof(SEARCH_WAY)).Length;
		SEARCH_WAY way = (SEARCH_WAY)(((int)curSearchWay+1)%totalWay);
		setSearchWay (way);
	}

	public void preWay()
	{
		searchImg.transform.localPosition = new Vector3 (-1000, 0, 0);
		playAni ani = searchImg.GetComponent<playAni> ();
		ani.stop ();

		int totalWay = Enum.GetNames (typeof(SEARCH_WAY)).Length;
		SEARCH_WAY way = (SEARCH_WAY)(((int)curSearchWay+totalWay-1)%totalWay);
		setSearchWay (way);
	}

	private void setSearchWay( SEARCH_WAY way, bool playAni = true )
	{
		// Debug.logger.Log (string.Format("setSearchWay({0}, {1})",way, playAni));
		if (playAni) 
		{
			LeanTween.moveLocalX (searchImg, oriPos.x, 0.3f);
		}
		else
		{
			searchImg.transform.localPosition = oriPos;
		}

		curSearchWay = way;
		playAni ani = searchImg.GetComponent<playAni> ();
		ani.setAniList (aniSprite[(int)way]);
		ani.play ();

		for(int index = 0;index < dotList.Length;index++)
		{
			float scale = ( (int)way == index ) ? 1.5f:1.0f;

			LeanTween.scale (dotList [index], Vector3.one * scale, 0.3f);
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class homeCtrl : MonoBehaviour 
{
	[SerializeField]
	private GameObject circle;
	[SerializeField]
	private Sprite[] circleSprite;
	[SerializeField]
	private GameObject menu;
	[SerializeField]
	private GameObject customUI;
	[SerializeField]
	private GameObject backBtn;
	[SerializeField]
	private GameObject infoBtn;
	[SerializeField]
	private GameObject mask;

	private Vector3 menuOriPos = Vector3.zero;
	private Stack<backAction> backStack;

	void Awake () 
	{
		menuOriPos = menu.transform.localPosition;
		backStack = new Stack<backAction> ();
	}

	void OnEnable()
	{
		hideMenu ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void setCircleColor( CIRCLE_COLOR mode)
	{
		Image img = circle.GetComponent<Image> ();

		int index = ((int)mode) % circleSprite.Length;
		img.sprite = circleSprite[index];
	}

	public void onCircleClick()
	{
		// menu 開著 那就收起來
		if (menu.activeInHierarchy) 
		{
			hideHomeUI ();
		} 
		else 
		{
			showHomeUI ();
		}
	}

	public void hideMenu()
	{
		menu.SetActive (false);
		mask.SetActive (false);
	}

	public void registBackAction(backAction action)
	{
		backStack.Push (action);
	}

	public void clearBackAction()
	{
		backStack.Clear ();
	}

	public void onBackClick()
	{
		hideMenu ();
		if( backStack.Count <= 0 )
		{
			pageMgr.Instance.prePage ();
		}
		else
		{
			backAction action = backStack.Pop ();
			action ();
		}
			
	}

	public void onInfoClick()
	{
		if (customUI.activeInHierarchy) 
		{
			hideCustomInfo ();
		}
		else 
		{
			showCustomInfo ();
		}

	}

	public void showInfoBtn()
	{
		LeanTween.moveLocalY (infoBtn,-120,0.3f);
		mask.SetActive (true);
	}

	public void OnMaskClick()
	{
		hideHomeUI ();
	}

	private void showCustomInfo()
	{
		// TODO 更新顧客資料
		// custom cus = DataMgr.Instance.getOrderingCustom();
		customUI.SetActive (true);
	}

	private void hideCustomInfo()
	{
		customUI.SetActive (false);
	}

	private void hideHomeUI()
	{
		LeanTween.scale (menu, Vector3.zero, 0.3f).setOnComplete(hideMenu);
		LeanTween.moveLocal (menu, circle.transform.localPosition, 0.3f);
		mask.SetActive (false);
	}

	private void showHomeUI()
	{
		menu.transform.localScale = Vector3.zero;
		menu.transform.localPosition = circle.transform.localPosition;
		menu.SetActive (true);

		infoBtn.transform.localPosition = backBtn.transform.localPosition;

		LeanTween.scale (menu, Vector3.one, 0.3f);
		LeanTween.moveLocal (menu, menuOriPos, 0.3f).setOnComplete(showInfoBtn);
	}
}

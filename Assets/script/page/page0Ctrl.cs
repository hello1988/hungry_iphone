﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page0Ctrl : pageBase 
{
	[SerializeField]
	private Sprite[] blueToothSprite;
	[SerializeField]
	private Image blueToothBtn;
	[SerializeField]
	private GameObject evaluationNumber;

	private bool isBlueToothOn;
	void Awake () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P0);
		setBlueTooth(false);

		setEvaluationNumber (2);
	}

	public void switchBlueTooth()
	{
		setBlueTooth(!isBlueToothOn);
	}

	public void setBlueTooth(bool isOn)
	{
		isBlueToothOn = isOn;
		blueToothBtn.sprite = isOn ? blueToothSprite[1]: blueToothSprite[0];
	}

	public void setEvaluationNumber(int num)
	{
		numberCtrl ctrl = evaluationNumber.GetComponent<numberCtrl> ();
		ctrl.setValue (num);
	}

	public void showEvaluationUI()
	{
		DataMgr.Instance.setP1Mode (0);
		pageMgr.Instance.nextPage (1);
	}

	public void showStatisticsUI()
	{
		DataMgr.Instance.setP1Mode (1);
		pageMgr.Instance.nextPage (1);
	}


	public void showSearchUI()
	{
		pageMgr.Instance.nextPage (2);
	}

}

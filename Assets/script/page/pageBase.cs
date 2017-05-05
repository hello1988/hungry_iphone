﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class pageBase : MonoBehaviour 
{
	[SerializeField]
	protected GameObject nextBtn;

	protected bool homeVisible = true;
	protected CIRCLE_COLOR circleColor = CIRCLE_COLOR.GREEN;

	public virtual void onPageEnable(){}

	void OnEnable() 
	{
		// page 忘記關閉就啟動時 會發生這個錯誤
		if (UIMgr.Instance == null) {return;}
			
		UIMgr.Instance.setHomeBtnVisible (homeVisible);
		UIMgr.Instance.setCircleColor (circleColor);
	}

	public void setNextBtnActive( bool isActive )
	{
		nextBtn.SetActive (isActive);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page5Ctrl : pageBase 
{
	[SerializeField]
	private GameObject trafficUI;
	[SerializeField]
	private GameObject MRTUI;

	void Awake () 
	{
		circleColor = CIRCLE_COLOR.YELLOW;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P5);
		trafficUI.SetActive (true);
		MRTUI.SetActive (false);
	}

	public void showMRTUI()
	{
		trafficUI.SetActive (false);
		MRTUI.SetActive (true);
	}

	public void nextPage()
	{
		pageMgr.Instance.nextPage (6);
	}
}

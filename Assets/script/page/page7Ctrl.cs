using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page7Ctrl : pageBase 
{
	[SerializeField]
	private GameObject stepUI;
	[SerializeField]
	private GameObject vedio;

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
		UIMgr.Instance.setBackground (BG.P6);

	}

	public void clickGO()
	{
		// TODO 影片播放測試
		nextPage ();
	}

	public void nextPage()
	{
		pageMgr.Instance.homePage();
	}

}

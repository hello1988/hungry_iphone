using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page2Ctrl : pageBase 
{
	[SerializeField]
	private GameObject searchUI;

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
		searchUI.SetActive (true);
	}

	public void nextPage( SEARCH_WAY way )
	{
		pageMgr.Instance.nextPage (3);
	}
}

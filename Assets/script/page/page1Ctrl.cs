using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page1Ctrl : pageBase 
{
	[SerializeField]
	private GameObject mode0;
	[SerializeField]
	private GameObject mode1;

	void Awake () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P1);

		int mode = DataMgr.Instance.getP1Mode ();
		bool isShowMode0 = (mode == 0);
		mode0.SetActive (isShowMode0);
		mode1.SetActive (!isShowMode0);


	}
}

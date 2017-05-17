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
		int mode = DataMgr.Instance.getP1Mode ();

		bool isShowMode0 = (mode == 0);
		mode0.SetActive (isShowMode0);
		mode1.SetActive (!isShowMode0);

		modeCtrlBase ctrl = null;
		if(mode == 0)
		{
			ctrl = mode0.GetComponent<mode0Ctrl> ();
		}
		else
		{
			ctrl = mode1.GetComponent<mode1Ctrl> ();
		}
		ctrl.init ();
	}

	public void changeMode( int mode )
	{
		UIMgr.Instance.clearBackAction ();
		DataMgr.Instance.setP1Mode (mode);

		onPageEnable ();
	}
}

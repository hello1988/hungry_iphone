using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class mode1Ctrl : modeCtrlBase
{
	[SerializeField]
	private GameObject statisticsUI;
	[SerializeField]
	private GameObject reportUI;
	[SerializeField]
	private GameObject[] dotList;

	[SerializeField]
	private Sprite[] statisticsSprite;
	[SerializeField]
	private Image statisticsImg;

	[SerializeField]
	private Sprite[] periodSprite;
	[SerializeField]
	private Image periodImg;

	[SerializeField]
	private float tweenSec = 0.3f;

	private int curIndex = 0;

	void Start () 
	{
		slideDectect dect = GetComponent<slideDectect> ();

		dect.registCallBack (DIRECTION.LEFT, slideLeft);
		dect.registCallBack (DIRECTION.RIGHT, slideRight);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void init()
	{
		UIMgr.Instance.setBackground (BG.P1_1);
		statisticsUI.SetActive (true);
		reportUI.SetActive (false);

		curIndex = 0;
		statisticsImg.sprite = statisticsSprite[curIndex];
		periodImg.sprite = periodSprite [curIndex];
		showDot (curIndex);

	}

	public void showReport(int index)
	{
		UIMgr.Instance.registBackAction (hideReportUI);

		statisticsUI.SetActive (false);
		reportUI.SetActive (true);

		reportCtrl ctrl = reportUI.GetComponent<reportCtrl> ();
		ctrl.showReport (index);
	}

	public void hideReportUI()
	{
		statisticsUI.SetActive (true);
		reportUI.SetActive (false);
	}

	public void slideLeft(float distance)
	{
		if(!statisticsUI.activeInHierarchy){return;}
		if( distance < 100 ){return;}

		if(curIndex >= (statisticsSprite.Length-1) ){return;}

		Vector3 moveDir = new Vector3 ( -800, 0, 0);
		curIndex++;

		slideAni ani = statisticsImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		statisticsImg.sprite = statisticsSprite[curIndex];
		ani.playAni (moveDir, tweenSec);

		ani = periodImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		periodImg.sprite = periodSprite[curIndex];
		ani.playAni (moveDir, tweenSec);

		showDot (curIndex);
	}

	public void slideRight(float distance)
	{
		if(!statisticsUI.activeInHierarchy){return;}
		if( distance < 100 ){return;}

		if(curIndex <= 0 ){return;}

		Vector3 moveDir = new Vector3 ( 800, 0, 0);
		curIndex--;

		slideAni ani = statisticsImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		statisticsImg.sprite = statisticsSprite[curIndex];
		ani.playAni (moveDir, tweenSec);

		ani = periodImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		periodImg.sprite = periodSprite[curIndex];
		ani.playAni (moveDir, tweenSec);

		showDot (curIndex);
	}

	private void showDot(int idx)
	{
		for( int index = 0;index < dotList.Length;index++ )
		{
			float scale = (index == idx) ? 1.5f: 1.0f;
			LeanTween.scale (dotList[index], Vector3.one*scale, tweenSec);
		}
	}
}

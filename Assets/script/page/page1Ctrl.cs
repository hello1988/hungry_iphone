using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page1Ctrl : pageBase 
{
	[SerializeField]
	private Sprite[] blueToothSprite;
	[SerializeField]
	private Image blueToothBtn;
	[SerializeField]
	private GameObject evaluationNumber;
	[SerializeField]
	private GameObject evaluationUI;

	private bool isBlueToothOn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P1);
		setBlueTooth(false);
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
		ctrl.setNumber (num);
	}

	public void showEvaluationUI()
	{
		evaluationUI.SetActive (true);
	}

	public void nextPage()
	{
		pageMgr.Instance.nextPage (2);
	}
}

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
	private GameObject mainUI;
	[SerializeField]
	private GameObject evaluationUI;
	[SerializeField]
	private GameObject searchUI;

	private bool isBlueToothOn;
	private GameObject[] UIList;
	void Awake () 
	{
		UIList = new GameObject[]{mainUI, evaluationUI, searchUI};
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P1);
		setBlueTooth(false);

		foreach (GameObject ui in UIList)
		{
			ui.SetActive (false);
		}
		mainUI.SetActive (true);
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
		foreach (GameObject ui in UIList)
		{
			ui.SetActive (false);
		}
		evaluationUI.SetActive (true);
	}

	public void hideEvaluationUI()
	{
		foreach (GameObject ui in UIList)
		{
			ui.SetActive (false);
		}
		mainUI.SetActive (true);
	}

	public void showSearchUI()
	{
		foreach (GameObject ui in UIList)
		{
			ui.SetActive (false);
		}
		searchUI.SetActive (true);
	}

	public void hideSearchUI()
	{
		foreach (GameObject ui in UIList)
		{
			ui.SetActive (false);
		}
		mainUI.SetActive (true);
	}

	public void nextPage()
	{
		pageMgr.Instance.nextPage (2);
	}
}

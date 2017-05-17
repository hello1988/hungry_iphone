using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page6Ctrl : pageBase 
{
	[SerializeField]
	private GameObject restaurantUI;
	[SerializeField]
	private GameObject detailUI;

	void Awake () 
	{
		circleColor = CIRCLE_COLOR.YELLOW;

		Button btn = nextBtn.GetComponent<Button> ();
		btn.onClick.AddListener (nextPage);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P6);

		restaurantUI.SetActive (true);
		detailUI.SetActive (false);

		restaurantCtrl ctrl = restaurantUI.GetComponent<restaurantCtrl> ();
		ctrl.init ();
	}

	public void nextPage()
	{
		UIMgr.Instance.clearBackAction ();
		pageMgr.Instance.nextPage (7);
	}

	public void showDetailUI( int restaurantID )
	{
		UIMgr.Instance.registBackAction (hideDetailUI);

		restaurantUI.SetActive (false);
		detailUI.SetActive (true);

		restaurantDetail ctrl = detailUI.GetComponent<restaurantDetail> ();
		ctrl.setInfo (restaurantID);
	}

	public void onItemDrop(GameObject obj)
	{
		
	}

	public void hideDetailUI()
	{
		restaurantUI.SetActive (true);
		detailUI.SetActive (false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page6Ctrl : pageBase 
{
	[SerializeField]
	private GameObject searchUI;
	[SerializeField]
	private GameObject restaurantUI;
	[SerializeField]
	private GameObject detailUI;

	private List<GameObject> UIList;
	void Awake () 
	{
		circleColor = CIRCLE_COLOR.YELLOW;

		Button btn = nextBtn.GetComponent<Button> ();
		btn.onClick.AddListener (nextPage);

		UIList = new List<GameObject> ();
		UIList.Add (searchUI);
		UIList.Add (restaurantUI);
		UIList.Add (detailUI);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P6);

		StopAllCoroutines ();

		showSearching ();

		StartCoroutine (waitForSearching());
	}

	public IEnumerator waitForSearching()
	{
		yield return new WaitForSeconds (3);

		hideAllUI ();
		restaurantUI.SetActive (true);

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

		hideAllUI ();
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

	private void showSearching()
	{
		hideAllUI ();
		searchUI.SetActive (true);
		searchWifi wifi = searchUI.GetComponent<searchWifi> ();
		wifi.init ();
	}

	private void hideAllUI()
	{
		foreach(GameObject obj in UIList)
		{
			obj.SetActive (false);
		}
	}
}

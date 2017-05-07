using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page4Ctrl : pageBase 
{
	[SerializeField]
	private GameObject budgetUI;

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
		UIMgr.Instance.setBackground (BG.P4);

		budgetCtrl ctrl = budgetUI.GetComponent<budgetCtrl> ();
		// ctrl.setBudgetNumber ( DataMgr.Instance.getBudget() );
		ctrl.showInputBudge();
	}

	public void nextPage()
	{
		pageMgr.Instance.nextPage (5);
	}
}

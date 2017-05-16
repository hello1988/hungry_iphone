using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode1Ctrl : MonoBehaviour 
{
	[SerializeField]
	private GameObject statisticsUI;
	[SerializeField]
	private GameObject reportUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		statisticsUI.SetActive (true);
		reportUI.SetActive (false);


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
}

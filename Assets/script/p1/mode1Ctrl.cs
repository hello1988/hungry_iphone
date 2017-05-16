using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class mode1Ctrl : MonoBehaviour
{
	[SerializeField]
	private GameObject statisticsUI;
	[SerializeField]
	private GameObject reportUI;

	// Use this for initialization
	void Start () 
	{
		slideDectect dect = GetComponent<slideDectect> ();

		dect.registCallBack (DIRECTION.LEFT, slideLeft);
		dect.registCallBack (DIRECTION.RIGHT, slideRight);
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

	public void slideLeft(float distance)
	{
		Debug.logger.Log (string.Format("slideLeft : {0}",distance));
	}

	public void slideRight(float distance)
	{
		Debug.logger.Log (string.Format("slideRight : {0}",distance));
	}
}

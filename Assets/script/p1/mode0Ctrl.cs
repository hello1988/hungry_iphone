using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mode0Ctrl : modeCtrlBase 
{
	[SerializeField]
	private GameObject menuUI;
	[SerializeField]
	private GameObject valuationUI;
	[SerializeField]
	private GameObject summitUI;

	private List<GameObject> UIList;

	void Awake () 
	{
		UIList = new List<GameObject> ();
		UIList.Add (menuUI);
		UIList.Add (valuationUI);
		UIList.Add (summitUI);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void init()
	{
		showUI(menuUI);
	}

	public void showEvaluationUI()
	{
		UIMgr.Instance.registBackAction (hideEvaluationUI);
		showUI(valuationUI);
	}

	public void hideEvaluationUI()
	{
		showUI(menuUI);
	}

	public void showSummitUI( int faceID )
	{
		DataMgr.Instance.setFaceID (faceID);
		UIMgr.Instance.registBackAction (hideSummitUI);
		showUI(summitUI);
	}

	public void hideSummitUI()
	{
		showUI(valuationUI);
	}

	private void showUI(GameObject UIObj)
	{
		foreach( GameObject obj in UIList )
		{
			obj.SetActive (false);
		}

		UIObj.SetActive (true);
		UIObj.SendMessage ("init", SendMessageOptions.DontRequireReceiver);
	}
}

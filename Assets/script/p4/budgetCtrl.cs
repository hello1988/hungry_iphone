﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class budgetCtrl : MonoBehaviour 
{
	[SerializeField]
	private GameObject inputBudge;
	[SerializeField]
	private GameObject budgeNumber;

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setBudgetNumber(int num)
	{
		inputBudge.SetActive (false);
		budgeNumber.SetActive (true);

		Text txt = budgeNumber.GetComponent<Text> ();
		txt.text = string.Format ("${0}",num);

	}

	public void showInputBudge()
	{
		inputBudge.SetActive (true);
		budgeNumber.SetActive (false);

		InputField inputField = inputBudge.GetComponent<InputField> ();
		inputField.text = "";
	}

	public void onEndEdit()
	{
		inputBudge.SetActive (false);
		budgeNumber.SetActive (true);

		InputField inputField = inputBudge.GetComponent<InputField> ();
		int newBudget = 0;
		if (!int.TryParse (inputField.text, out newBudget)) {return;}

		DataMgr.Instance.setBudget (newBudget);

		Text txt = budgeNumber.GetComponent<Text> ();
		txt.text = string.Format ("${0}",newBudget);
	}
}

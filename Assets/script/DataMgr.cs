using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Const
{

	public enum BG
	{
		P0,
		P3,
		P4,
	}

	public enum CIRCLE_COLOR
	{
		GREEN,
		YELLOW,
	}

	public enum SEARCH_WAY
	{
		WAY1,
		WAY2,
		WAY3,
	}
}

public class DataMgr : MonoBehaviour 
{
	private static DataMgr _instance = null;
	public static DataMgr Instance
	{
		get{return _instance;}
	}

	private int budget = 300;

	// Use this for initialization
	private void Awake ()
	{
		_instance = this;
	}

	public void Start()
	{
		budget = 300;
	}

	public void resetData()
	{
		Start ();
	}

	public int getBudget()
	{
		return budget;
	}

	public void setBudget ( int num )
	{
		budget = num;
	}
}


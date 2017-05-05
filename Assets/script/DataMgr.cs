using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Const
{

	public enum BG
	{
		P1,
	}
}

public class DataMgr : MonoBehaviour 
{
	private static DataMgr _instance = null;
	public static DataMgr Instance
	{
		get{return _instance;}
	}

	// Use this for initialization
	private void Awake ()
	{
		_instance = this;
	}

	public void Start()
	{
	}

	public void resetData()
	{
		Start ();
	}
}


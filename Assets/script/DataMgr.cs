using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

namespace Const
{

	public enum BG
	{
		P0,
		P1_1,
		P3,
		P4,
		P5,
		P6,
		P1_0,
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

	public enum TRAFFIC_WAY
	{
		WALK,
		TYPE_IN,
		MRT,
	}

	public enum DIRECTION
	{
		UP,
		RIGHT,
		DOWN,
		LEFT,
	}

	public delegate void backAction();
	public delegate void slideCallBack(float distance);
}

public class DataMgr : MonoBehaviour 
{
	private static DataMgr _instance = null;
	public static DataMgr Instance
	{
		get{return _instance;}
	}

	private int budget = 300;
	TRAFFIC_WAY trafficWay = TRAFFIC_WAY.WALK;
	private int p1Mode = 0;
	private int faceID = 0;

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

	public TRAFFIC_WAY getTrafficWay()
	{
		return trafficWay;
	}

	public void setTrafficWay(TRAFFIC_WAY way)
	{
		trafficWay = way;
	}

	/**
	* mode 0 評價UI
	* mode 1 統計UI
	*/
	public void setP1Mode( int mode )
	{
		p1Mode = mode;
	}

	public int getP1Mode()
	{
		return p1Mode;
	}

	public void setFaceID( int face )
	{
		faceID = face;
	}

	public int getFaceID()
	{
		return faceID;
	}
}


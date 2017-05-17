using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class menuUICtrl : MonoBehaviour 
{

	[SerializeField]
	private Sprite[] menuNameList;
	[SerializeField]
	private Image menuNameImg;
	[SerializeField]
	private float slideDistance = 100;
	[SerializeField]
	private float aniSec = 0.3f;

	private int curMenu = 0;
	void Start () 
	{
		slideDectect dect = menuNameImg.GetComponent<slideDectect> ();
		dect.registCallBack (DIRECTION.UP, nextMenu);
		dect.registCallBack (DIRECTION.DOWN, preMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		UIMgr.Instance.setBackground (BG.P1_0);
		curMenu = 0;
		menuNameImg.sprite = menuNameList [curMenu];
	}

	public void nextMenu(float distance)
	{
		if (distance < slideDistance) {return;}

		if( curMenu >= (menuNameList.Length-1) ){return;}

		slideAni ani = menuNameImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		curMenu++;
		menuNameImg.sprite = menuNameList[curMenu];

		Vector3 moveDir = new Vector3 ( 0, 900, 0);
		ani.playAni (moveDir, aniSec);
	}

	public void preMenu(float distance)
	{
		if (distance < slideDistance) {return;}

		if( curMenu <= 0 ){return;}

		slideAni ani = menuNameImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		curMenu--;
		menuNameImg.sprite = menuNameList[curMenu];

		Vector3 moveDir = new Vector3 ( 0, -900, 0);
		ani.playAni (moveDir, aniSec);
	}
}

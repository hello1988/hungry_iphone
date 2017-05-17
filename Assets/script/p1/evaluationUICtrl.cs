using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class evaluationUICtrl : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] faceList;
	[SerializeField]
	private Image faceImg;

	[SerializeField]
	private mode0Ctrl modeCtrl;
	[SerializeField]
	private GameObject[] dotList;
	[SerializeField]
	private float tweenSec = 0.3f;
	[SerializeField]
	private float slideDistance = 100;

	private int curFace = 0;
	void Start () 
	{
		slideDectect dect = faceImg.GetComponent<slideDectect> ();
		dect.registCallBack (DIRECTION.LEFT, nextFace);
		dect.registCallBack (DIRECTION.RIGHT, preFace);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		UIMgr.Instance.setBackground (BG.P1_1);
		curFace = 0;
		faceImg.sprite = faceList[curFace];
		showDot( curFace );
	}

	public void nextFace(float distance)
	{
		if (distance < slideDistance) 
		{
			modeCtrl.showSummitUI (curFace);
			return;
		}

		if( curFace >= (faceList.Length-1) ){return;}

		slideAni ani = faceImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		curFace++;
		faceImg.sprite = faceList[curFace];

		Vector3 moveDir = new Vector3 ( -800, 0, 0);
		ani.playAni (moveDir, tweenSec);

		showDot( curFace );
	}

	public void preFace(float distance)
	{
		if (distance < slideDistance)  
		{
			modeCtrl.showSummitUI (curFace);
			return;
		}

		if( curFace <= 0 ){return;}

		slideAni ani = faceImg.GetComponent<slideAni> ();
		ani.makeShadow ();
		curFace--;
		faceImg.sprite = faceList[curFace];

		Vector3 moveDir = new Vector3 ( 800, 0, 0);
		ani.playAni (moveDir, tweenSec);

		showDot( curFace );
	}

	private void showDot( int idx )
	{
		for( int index = 0;index < dotList.Length;index++ )
		{
			float scale = (index == idx) ? 1.5f: 1.0f;
			LeanTween.scale ( dotList[index], Vector3.one*scale, tweenSec );
		}
	}
}

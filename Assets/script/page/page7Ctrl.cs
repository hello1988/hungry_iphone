using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page7Ctrl : pageBase 
{
	[SerializeField]
	private GameObject stepUI;
	[SerializeField]
	private GameObject navigation;
	[SerializeField]
	private Sprite[] stepSprite;
	[SerializeField]
	private scrollCtrl stepScroll;

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
		UIMgr.Instance.setBackground (BG.P6);

		stepUI.SetActive (true);
		navigation.SetActive (false);
		nextBtn.SetActive (false);

		stepScroll.reset ();
		for( int index = 0;index < stepSprite.Length;index++ )
		{
			GameObject newObj = stepScroll.addItem ();

			Image img = newObj.GetComponent<Image> ();
			img.sprite = stepSprite [index];
			if(index == (stepSprite.Length - 1) )
			{
				Button btn = newObj.AddComponent<Button> ();
				btn.onClick.AddListener (clickGO);
			}
		}


	}

	public void clickGO()
	{
		// TODO 影片播放測試
		stepUI.SetActive(false);
		navigation.SetActive (true);

		navigationCtrl ctrl = navigation.GetComponent<navigationCtrl> ();
		ctrl.init ();
	}

	public void showHomeBtn()
	{
		nextBtn.SetActive (true);
	}

	public void nextPage()
	{
		pageMgr.Instance.homePage();
	}

}

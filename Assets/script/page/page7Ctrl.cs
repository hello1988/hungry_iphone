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
	private GameObject vedio;
	[SerializeField]
	private Sprite[] stepSprite;
	[SerializeField]
	private scrollCtrl stepScroll;
	[SerializeField]
	private float vedioSec = 3;
	[SerializeField]
	private movieCtrl movie;

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
		vedio.SetActive (false);
		nextBtn.SetActive (false);
		movie.stop ();

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
		vedio.SetActive (true);

		movie.play ();
		StartCoroutine (showHomeBtn());
	}

	public IEnumerator showHomeBtn()
	{
		yield return new WaitForSeconds (vedioSec);

		nextBtn.SetActive (true);
	}

	public void nextPage()
	{
		movie.stop ();
		pageMgr.Instance.homePage();
	}

}

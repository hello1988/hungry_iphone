using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class page3Ctrl : pageBase 
{
	[SerializeField]
	private Sprite[] filterLargeSprite;
	[SerializeField]
	private Image focusImage;

	private int curIndex;

	void Awake () 
	{
		Button btn = nextBtn.GetComponent<Button> ();
		btn.onClick.AddListener (nextPage);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void onPageEnable() 
	{
		UIMgr.Instance.setBackground (BG.P3);
		setFocusImage( 0 );
	}

	public void onFilterClick( int filterIndex )
	{
		
	}

	public void onItemDrop( GameObject obj )
	{
		int nextIndex = (curIndex + 1) % filterLargeSprite.Length;
		setFocusImage( nextIndex );
	}

	private void setFocusImage( int index )
	{
		if( (index < 0) || (index >= filterLargeSprite.Length) ){return;}

		curIndex = index;
		focusImage.sprite = filterLargeSprite [index];
	}

	public void nextPage()
	{
		pageMgr.Instance.nextPage (4);
	}
}

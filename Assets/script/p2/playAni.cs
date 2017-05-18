using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class playAni : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] spriteList;
	[SerializeField]
	private float swapSec = 3.0f;

	private Sprite[] aniList;
	private int spriteIndex = 0;
	private bool isLoop = true;
	private backAction completeCallBack = null;
	void Awake () 
	{
		if ((spriteList != null) && (spriteList.Length > 0)) 
		{
			aniList = spriteList;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setAniList( Sprite[] newSpriteList )
	{
		aniList = newSpriteList;
		spriteIndex = 0;
		Image img = GetComponent<Image> ();
		img.sprite = aniList [spriteIndex];
	}

	public void setLoop( bool loop, backAction callBack=null )
	{
		isLoop = loop;
		completeCallBack = callBack;
	}

	public void play()
	{
		StopAllCoroutines ();
		if (!gameObject.activeInHierarchy) {return;}

		StartCoroutine ( nextSprite() );
	}

	public void stop()
	{
		StopAllCoroutines ();

		Image img = GetComponent<Image> ();
		img.sprite = aniList [0];
	}

	private IEnumerator nextSprite()
	{
		Image img = GetComponent<Image> ();
		img.sprite = aniList [spriteIndex];
		spriteIndex = (spriteIndex + 1) % aniList.Length;

		yield return new WaitForSeconds (swapSec);

		if (!isLoop && (spriteIndex >= (aniList.Length - 1))) 
		{
			img.sprite = aniList [spriteIndex];
			if (completeCallBack != null) 
			{
				completeCallBack ();
			}
		}
		else
		{
			play ();
		}
	}
}

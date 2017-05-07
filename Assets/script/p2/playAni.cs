using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playAni : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] spriteList;
	[SerializeField]
	private float swapSec = 3.0f;

	private Sprite[] aniList;
	private int spriteIndex;

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

	public void play()
	{
		StopAllCoroutines ();
		StartCoroutine ( nextSprite() );
	}

	public void stop()
	{
		StopAllCoroutines ();
	}

	private IEnumerator nextSprite()
	{
		yield return new WaitForSeconds (swapSec);

		spriteIndex = (spriteIndex + 1) % aniList.Length;
		Image img = GetComponent<Image> ();
		img.sprite = aniList [spriteIndex];
		play ();
	}
}

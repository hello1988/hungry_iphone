using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tweenAlpha : MonoBehaviour {
	[SerializeField]
	private float tweenSec = 0.5f;

	public void play()
	{
		fadeOut ();
	}

	private void setSpriteAlpha( float val )
	{
		
		Image img = GetComponent<Image> ();

		img.color = new Color (1,1,1,val);
	}

	private void fadeOut()
	{
		if (!gameObject.activeInHierarchy) {return;}

		LeanTween.value (gameObject, setSpriteAlpha, 1, 0, tweenSec).setOnComplete(fadeIn);
	}

	private void fadeIn()
	{
		if (!gameObject.activeInHierarchy) {return;}

		LeanTween.value (gameObject, setSpriteAlpha, 0, 1, tweenSec).setOnComplete(fadeOut);
	}
}

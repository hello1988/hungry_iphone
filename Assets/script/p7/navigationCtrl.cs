using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class navigationCtrl : MonoBehaviour 
{
	[SerializeField]
	private Sprite[] spriteList;
	[SerializeField]
	private Sprite[] arrowSprite;
	[SerializeField]
	private float swapSec = 3.0f;

	[SerializeField]
	private page7Ctrl pageCtrl;
	[SerializeField]
	private Image floor;
	[SerializeField]
	private Image arrow;
	[SerializeField]
	private Vector3 arrowPos1 = Vector3.zero;
	[SerializeField]
	private Vector3 arrowPos2 = Vector3.zero;
	[SerializeField]
	private Vector3 arrowPos3 = Vector3.zero;

	private List<Vector3> arrowPosList;
	private int spriteIndex = 0;
	void Awake () {
		arrowPosList = new List<Vector3> ();
		arrowPosList.Add (arrowPos1);
		arrowPosList.Add (arrowPos2);
		arrowPosList.Add (arrowPos3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		StopAllCoroutines ();

		spriteIndex = 0;
		StartCoroutine( setNavigation (spriteIndex) );
	}

	public IEnumerator setNavigation( int index )
	{
		floor.sprite = spriteList [index];

		if (index <= (arrowSprite.Length - 1)) 
		{
			arrow.gameObject.SetActive (true);
			arrow.sprite = arrowSprite[index];
			arrow.SetNativeSize ();
			arrow.transform.localPosition = arrowPosList[index];

			tweenAlpha tween = arrow.GetComponent<tweenAlpha> ();
			tween.play ();
		}
		else 
		{
			arrow.gameObject.SetActive (false);
		}

		if (spriteIndex >= (spriteList.Length - 1)) 
		{
			showHomeBtn ();
		}

		yield return new WaitForSeconds (swapSec);
		nextNavigation ();
	}

	private void showHomeBtn()
	{
		pageCtrl.showHomeBtn ();
	}

	private void nextNavigation()
	{
		StopAllCoroutines ();

		if (spriteIndex >= (spriteList.Length - 1)) 
		{
			return;
		}

		if (!gameObject.activeInHierarchy) {return;}

		spriteIndex++;
		StartCoroutine (setNavigation( spriteIndex ));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MrtCtrl : MonoBehaviour 
{
	[SerializeField]
	private GameObject MRTLine;
	[SerializeField]
	private GameObject station;

	[SerializeField]
	private Sprite[] lineSpriteList;
	[SerializeField]
	private scrollCtrl lineScroll;



	private bool scrollInit = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showMRTStation()
	{
		UIMgr.Instance.registBackAction (showMRTLine);

		MRTLine.SetActive (false);
		station.SetActive (true);
	}

	public void showMRTLine()
	{
		MRTLine.SetActive (true);
		station.SetActive (false);

		initScroll ();
	}

	private void initScroll()
	{
		if(scrollInit){return;}

		scrollInit = true;

		lineScroll.reset ();
		for(int index = 0;index < lineSpriteList.Length;index++)
		{
			GameObject newObj = lineScroll.addItem ();

			Image img = newObj.GetComponent<Image> ();
			img.sprite = lineSpriteList [index];
		}
	}
}

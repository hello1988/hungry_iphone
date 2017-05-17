using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class summitUICtrl : MonoBehaviour 
{
	[SerializeField]
	private GameObject infoimg;
	[SerializeField]
	private GameObject writeBtn;
	[SerializeField]
	private GameObject saveBtn;
	[SerializeField]
	private GameObject replyBG;
	[SerializeField]
	private GameObject home1;
	[SerializeField]
	private GameObject home2;

	[SerializeField]
	private Sprite[] faceLlist;
	[SerializeField]
	private Sprite cupon;
	[SerializeField]
	private Sprite replySprite;

	private List<GameObject> UIList;

	void Awake () 
	{
		UIList = new List<GameObject> ();

		UIList.Add (infoimg);
		UIList.Add (writeBtn);
		UIList.Add (saveBtn);
		UIList.Add (replyBG);
		UIList.Add (home1);
		UIList.Add (home2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void backToPage0()
	{
		UIMgr.Instance.clearBackAction ();
		pageMgr.Instance.nextPage (0);
	}

	public void init()
	{
		UIMgr.Instance.setBackground (BG.P1_0);

		showFace ();
	}

	public void showFace()
	{
		hideAllUI ();

		infoimg.SetActive (true);
		writeBtn.SetActive (true);
		saveBtn.SetActive (true);

		int faceID = DataMgr.Instance.getFaceID ();
		Image img = infoimg.GetComponent<Image> ();
		img.sprite = faceLlist [faceID];
		img.SetNativeSize ();
	}

	public void showCupon()
	{
		UIMgr.Instance.registBackAction (showFace);
		hideAllUI ();

		home2.SetActive (true);
		infoimg.SetActive (true);

		Image img = infoimg.GetComponent<Image> ();
		img.sprite = cupon;
		img.SetNativeSize ();

	}

	public void showReply()
	{
		UIMgr.Instance.registBackAction (showFace);
		hideAllUI ();

		home1.SetActive (true);
		replyBG.SetActive (true);

		StartCoroutine (changeReply());
	}

	private IEnumerator changeReply()
	{
		yield return new WaitForSeconds (2);

		infoimg.SetActive (true);

		Image img = infoimg.GetComponent<Image> ();
		img.sprite = replySprite;
		img.SetNativeSize ();

	}

	private void hideAllUI()
	{
		StopAllCoroutines ();

		foreach( GameObject obj in UIList )
		{
			obj.SetActive (false);
		}
	}
}

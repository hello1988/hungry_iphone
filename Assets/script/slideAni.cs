using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slideAni : MonoBehaviour 
{
	private GameObject shadow;
	private Vector3 finalPos;

	void Awake () 
	{
		shadow = new GameObject ("shadow");
		shadow.AddComponent<Image> ();
		shadow.SetActive (false);
		shadow.transform.SetParent (transform.parent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void makeShadow()
	{
		makeShadow (transform.localPosition);
	}

	public void makeShadow( Vector3 finalPossition )
	{
		shadow.SetActive (true);

		Image shadowImg = shadow.GetComponent<Image> ();
		Image targetImg = GetComponent<Image> ();
		shadowImg.sprite = targetImg.sprite;

		shadow.transform.localPosition = transform.localPosition;
		shadow.transform.localScale = transform.localScale;

		RectTransform shadowRect = shadow.GetComponent<RectTransform> ();
		RectTransform rect = GetComponent<RectTransform> ();
		shadowRect.sizeDelta = rect.sizeDelta;

		finalPos = finalPossition;
	}

	public void playAni( Vector3 moveDir, float moveSec )
	{
		transform.localPosition -= moveDir;

		Vector3 shadowPos = shadow.transform.localPosition;

		LeanTween.moveLocal (gameObject, finalPos, moveSec);
		LeanTween.moveLocal (shadow, (shadowPos + moveDir), moveSec).setOnComplete(hideShadow);
	}

	public void hideShadow()
	{
		shadow.SetActive (false);
	}
}

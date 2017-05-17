using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class navigationCtrl : MonoBehaviour 
{
	[SerializeField]
	private page7Ctrl pageCtrl;
	[SerializeField]
	private GameObject floor;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		playAni ani =  floor.GetComponent<playAni> ();
		ani.stop ();

		ani.setLoop (false, showHomeBtn );
		ani.play ();
	}

	public void showHomeBtn()
	{
		pageCtrl.showHomeBtn ();
	}
}

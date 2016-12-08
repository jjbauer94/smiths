using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MAILTYPE
{
	ERROR = 0,
	MOVETO = 1,
	PLAYERPOSITION = 2,
	FUNCTION = 3,
}

public class Mail
{
	public MAILTYPE mail;
	public List<int> PlayerNumbers;
	public string instruction;
	public string functionCall;
}

public abstract class MoveToMail : Mail
{
	public int platformID;
	public int movePointID;
}

public class messageMan : MonoBehaviour
{
	static messageMan instance;
	private bool initGame = false;

	// Use this for initialization
	void Start ()
	{
		//On start assign this as the singleton target
		instance = this;
	}

	messageMan getInstance()
	{
		if (instance == null)
		{
			instance = GameObject.Find("messageMan").GetComponent<messageMan>();
		}
		return instance;
	}

	void FixedUpdate ()
	{
		if (initGame == false)
		{

		}
	}
}

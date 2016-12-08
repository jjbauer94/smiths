using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inputMan : MonoBehaviour
{
	[SerializeField]
	private List<Mail> inbox;
	[SerializeField]
	private List<Mail> outbox;

	public static inputMan instance { get; private set; }

	protected void Awake()
	{
		if (instance == null)
		{
			instance = GameObject.Find("inputMan").GetComponent<inputMan>();
		}
	}

	// Use this for initialization
	void Start ()
	{
		inbox = new List<Mail>();
		outbox = new List<Mail>();
	}
	
	void FixedUpdate() {
	
	}

	//Stores any mail received
	public void receiveMail(Mail message)
	{
		inbox.Add(message);
	}

	public void processOutbox(Mail message)
	{
	}
}

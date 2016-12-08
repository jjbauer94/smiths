using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	[SerializeField]
	private List<Mail> inbox;
	[SerializeField]
	private List<Mail> outbox;

	// Use this for initialization
	void Start ()
	{
		inbox = new List<Mail>();
		outbox = new List<Mail>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void moveTo()
	{

	}

	//Stores any mail received
	void receiveMail(Mail message)
	{
		inbox.Add(message);
	}

	void sendMail(Mail message)
	{
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePoint : MonoBehaviour
{
	[SerializeField]
	private List<Mail> inbox;
	[SerializeField]
	private List<Mail> outbox;
	private bool occupied = false;

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

	void FixedUpdate()
	{

	}

	private void playerArrive()
	{

	}

	//Stores any mail received
	private void receiveMail(Mail message)
	{
		inbox.Add(message);
	}

	private void sendMail(Mail message)
	{
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class messageMan : MonoBehaviour
{
	public static messageMan instance { get; private set; }

	protected void Awake()
	{
		if (instance == null)
		{
			instance = GameObject.Find("messageMan").GetComponent<messageMan>();
		}
	}

	private bool initGame = false;
	private List<Mail> inbox;
	private List<Mail> outbox;


	// Use this for initialization
	void Start ()
	{
		inbox = new List<Mail>();
		outbox = new List<Mail>();
		
		//On start assign this as the singleton target
		instance = this;
	}

	void FixedUpdate ()
	{
		if (initGame == false)
		{

		}

		processInbox();
		processOutbox();
	}

	void forwardMail(Mail forward)
	{
		switch (((ForwardMail)forward).resendAsType)
		{
			case MAILTYPE.ERROR:
				{
					Debug.Log("Forward resendAsType set to ERROR");
					break;
				}
			case MAILTYPE.FORWARDMAIL:
				{
					Debug.Log("Forward resendAsType set to FORWARDMAIL - This is an error");
					break;
				}
			case MAILTYPE.FUNCTION:
				{
					FunctionMail newMail = new FunctionMail();
					newMail.mailType = ((ForwardMail)forward).resendAsType;
					newMail.destination = ((ForwardMail)forward).destination;
					newMail.functionCall = ((ForwardMail)forward).functionCall;
					newMail.instruction = ((ForwardMail)forward).instruction;
					outbox.Add(newMail);
					break;
				}
			case MAILTYPE.MOVETO:
				{
					MoveToMail newMail = new MoveToMail();
					newMail.mailType = ((ForwardMail)forward).resendAsType;
					newMail.destination = ((ForwardMail)forward).destination;
					newMail.instruction = ((ForwardMail)forward).instruction;
					newMail.movePointID = ((ForwardMail)forward).movePointID;
					newMail.platformID = ((ForwardMail)forward).platformID;
					newMail.playerIDs = ((ForwardMail)forward).playerIDs;
                    break;
				}
			case MAILTYPE.PLAYERPOSITION:
				{
					PlayerPosMail newMail = new PlayerPosMail();
					newMail.mailType = ((ForwardMail)forward).resendAsType;
					newMail.destination = ((ForwardMail)forward).destination;
					newMail.instruction = ((ForwardMail)forward).instruction;
					newMail.platformID = ((ForwardMail)forward).platformID;
					newMail.playerID = ((ForwardMail)forward).playerID;
					break;
				}
		}
	}
	
	private void processInbox()
	{
		while(inbox.Count != 0)
        {
			switch (inbox[0].mailType)
			{
				case MAILTYPE.ERROR:
					{
						Debug.Log("Error message sent");
						break;
					}
				case MAILTYPE.FORWARDMAIL:
					{
						forwardMail(inbox[0]);						
                        break;
					}
				case MAILTYPE.FUNCTION:
					{
						FunctionMail functionMail = (FunctionMail)inbox[0];
						break;
					}
			}
			//Remove the mail I just processed
			inbox.RemoveAt(0);
		}
	}

	//Stores any mail received
	void receiveMail(Mail message)
	{
		inbox.Add(message);
	}

	void processOutbox()
	{
		while (outbox.Count != 0)
		{
			switch (outbox[0].destination)
			{
				case DESTINATION.ALL:
					{
						platMan.instance.receiveMail(outbox[0]);
						instance.receiveMail(outbox[0]);
						playerMan.instance.receiveMail(outbox[0]);
						inputMan.instance.receiveMail(outbox[0]);
						break;
					}
				case DESTINATION.INPUTMAN:
					{
						inputMan.instance.receiveMail(outbox[0]);
						break;
					}
				case DESTINATION.MESSAGEMAN:
					{
						instance.receiveMail(outbox[0]);
						break;
					}
				case DESTINATION.PLATMAN:
					{
						platMan.instance.receiveMail(outbox[0]);
						break;
					}
				case DESTINATION.PLAYERMAN:
					{
						playerMan.instance.receiveMail(outbox[0]);
						break;
					}
			}
			//Remove the mail I just processed
			outbox.RemoveAt(0);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}


//By default, this will be set to error. Which everybody will discard and log an error
public enum MAILTYPE
{
	ERROR = 0,
	MOVETO = 1,
	PLAYERPOSITION = 2,
	FUNCTION = 3,
	FORWARDMAIL = 4,
}

//By default, sends to all managers
public enum DESTINATION
{
	ALL = 0,
	PLATMAN = 1,
	MESSAGEMAN = 2,
	PLAYERMAN = 3,
	INPUTMAN = 4,
}

public abstract class Mail
{
	public MAILTYPE mailType;
	public DESTINATION destination;
	public string instruction;
}

public class MoveToMail : Mail
{
	public List<int> playerIDs;
	public int platformID;
	public int movePointID;
}

public class PlayerPosMail : Mail
{
	public int playerID;
	public int platformID;
	public int movePointID;
}

public class FunctionMail : Mail
{
	public string functionCall;
}

/*Must contain all data available in other mail types, 
  as this type can become any other type*/
public class ForwardMail : Mail
{
	public List<int> playerIDs;
	public int playerID;
	public int platformID;
	public int movePointID;
	public string functionCall;
	public MAILTYPE resendAsType;
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerMan : MonoBehaviour
{

	public static playerMan instance { get; private set; }

	protected void Awake()
	{
		if (instance == null)
		{
			instance = GameObject.Find("playerMan").GetComponent<playerMan>();
		}
	}

	public GameObject playerPrefab;
	
	public List<GameObject> playerList;

	[SerializeField]
	private List<Mail> inbox;
	[SerializeField]
	private List<Mail> outbox;
	[SerializeField]
	private int numPlayers;
	[SerializeField]
	private int currTurn;

	// Use this for initialization
	void Start ()
	{
		inbox = new List<Mail>();
		outbox = new List<Mail>();
	}

	void generatePlayer(GameObject destination)
	{
		generatePlayer(1, destination);
	}

	void generatePlayer(int amount, GameObject destination)
	{
		numPlayers++;
		if (playerPrefab != null)
		{
			playerList.Add(Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject);
			playerList[numPlayers - 1].transform.parent = transform;
		}
		else
		{
			Debug.Log("playerPrefab is null");
		}
		
	}

	private void processInbox()
	{
		while (inbox.Count != 0)
		{
			switch (inbox[0].mailType)
			{
				case MAILTYPE.ERROR:
					{
						break;
					}
				case MAILTYPE.FORWARDMAIL:
					{
						break;
					}
				case MAILTYPE.FUNCTION:
					{
						break;
					}
				case MAILTYPE.MOVETO:
					{
						break;
					}
				case MAILTYPE.PLAYERPOSITION:
					{
						break;
					}
			}
			//Remove the mail I just processed
			inbox.RemoveAt(0);
		}
	}

	public playerMan getInstance()
	{
		if (instance == null)
		{
			instance = GameObject.Find("playerMan").GetComponent<playerMan>();
		}
		return instance;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void FixedUpdate()
	{

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
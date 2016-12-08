using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class platMan : MonoBehaviour
{
	[SerializeField]
	private List<Mail> inbox;
	[SerializeField]
	private List<Mail> outbox;

	public GameObject[] platforms;

	private GameObject GO;
	public static platMan instance { get; private set; }

	protected void Awake()
	{
		if(instance == null)
		{
			instance = GameObject.Find("platMan").GetComponent<platMan>();
		}
	}

	// Use this for initialization
	void Start()
	{
		GO = gameObject;
		inbox = new List<Mail>();
		outbox = new List<Mail>();

		if (platforms.Length == 0)
		{
			int numPlatforms = transform.childCount;
			platforms = new GameObject[numPlatforms];

			for (int i = 0; i < numPlatforms; i++)
			{
				platforms[i] = transform.GetChild(i).gameObject;
			}
		}
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

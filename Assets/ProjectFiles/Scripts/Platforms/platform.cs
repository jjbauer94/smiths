using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class platform : MonoBehaviour
{
	public GameObject movePointPrefab;
	public Vector3[] movePointLocation;

	[SerializeField]
	private List<Mail> inbox;
	[SerializeField]
	private List<Mail> outbox;
	[SerializeField]
	private List<GameObject> movePointList = new List<GameObject>();

	private GameObject GO;
	private Transform TR;

	// Use this for initialization
	void Start ()
	{
		inbox = new List<Mail>();
		outbox = new List<Mail>();

		GO = gameObject;
		TR = transform;

		if (movePointPrefab == null)
		{
			Debug.Log("movePointPrefab == null - " + gameObject.name);
			return;
		}
		if (movePointLocation.Length == 0)
		{
			movePointLocation = new Vector3[4];
			movePointLocation[0] = new Vector3(TR.position.x, 0, TR.position.z + 0.25f);
			movePointLocation[1] = new Vector3(TR.position.x, 0, TR.position.z - 0.25f);
			movePointLocation[2] = new Vector3(TR.position.x + 0.25f, 0, TR.position.z);
			movePointLocation[3] = new Vector3(TR.position.x - 0.25f, 0, TR.position.z);
		}

		for (int i = 0; i < movePointLocation.Length; i++)
		{
			movePointList.Add(Instantiate(movePointPrefab, movePointLocation[i], Quaternion.identity) as GameObject);
			movePointList[i].transform.parent = TR;
		}
	}
	
	// Update is called once per frame
	void Update ()
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

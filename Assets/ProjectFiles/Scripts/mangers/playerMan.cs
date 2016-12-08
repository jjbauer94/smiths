using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerMan : MonoBehaviour
{
	static playerMan instance;
	public GameObject playerPrefab;
	[SerializeField] private int numPlayers;
	[SerializeField] private int currTurn;
	public List<GameObject> playerList;

	// Use this for initialization
	void Start ()
	{
		instance = this;
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

	public playerMan getInstance()
	{
		if (instance == null)
		{
			instance = GameObject.Find("playerMan").GetComponent<playerMan>();
		}
		return instance;
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
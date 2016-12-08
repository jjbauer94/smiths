using UnityEngine;
using System.Collections;

public class platMan : MonoBehaviour
{
	public GameObject[] platforms;

	private GameObject GO;
	static private platMan instance;

	// Use this for initialization
	void Start()
	{
		GO = gameObject;

		//On start set this up as the singleton target
		instance = this;

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

	platMan getInstance()
	{
		if (instance == null)
		{
			instance = GameObject.Find("platMan").GetComponent<platMan>();
		}
		return instance;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

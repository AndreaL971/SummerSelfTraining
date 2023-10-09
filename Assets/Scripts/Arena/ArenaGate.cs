using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArenaGate : MonoBehaviour
{
	public Transform bossSpawnPoint;
	public GameObject arenaWall;
	public GameObject forwardWall;
	public GameObject boss;
	private GameObject arenaBoss;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (arenaBoss.IsDestroyed())
		{
			forwardWall.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!arenaWall.activeSelf)
			{
				arenaWall.SetActive(true);
				arenaBoss = Instantiate(boss, bossSpawnPoint.position, Quaternion.Euler(0, 90, 0));
			}
		}
	}
}

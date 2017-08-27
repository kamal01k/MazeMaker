﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

	public MazeMaker mazeMaker;

	public bool UsesDestructiveAlgorithm { get; set; }
	public int Columns = 5; // consider making these properties again when you build a UI for the web player
	public int Rows = 4;    // and no longer need to access the values directly in the inspector
	[SerializeField]
	public WaitForSeconds Delay = new WaitForSeconds(0f); 

	void Start () {

		UsesDestructiveAlgorithm = true;

		LoadMaze();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			RestartMaze();
		}
	}
	
	void LoadMaze () {

		if (UsesDestructiveAlgorithm)
		{
			StartCoroutine(mazeMaker.BuildTheEggCarton(Rows, Columns, Delay));
		}
		else
		{
			StartCoroutine(mazeMaker.GenerateCells(Rows, Columns, Delay));
		}
		
	}

	void RestartMaze ()
	{
		Destroy(mazeMaker.gameObject);
		LoadMaze();
	}
}

﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public int scale;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,scale * Time.deltaTime);
		//transform.Rotate (0, Time.deltaTime, 0, Space.World);
	}
}

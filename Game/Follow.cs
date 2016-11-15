using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	private Transform player;
	private UnityEngine.AI.NavMeshAgent nav;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		nav.SetDestination (player.position);
	}
}

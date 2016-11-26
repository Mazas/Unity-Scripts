using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour {
    public float maxDistance=4; //At this distance it starts following
    public float minDistance=2; //At this distance it stops following

    private GameObject player;
    private NavMeshAgent nav;
    private Animator anim;
    private float distance;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 2f;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position,player.transform.position);
        if (distance >= maxDistance)
        {
            FollowPlayer();
        }
        else if (distance<=minDistance)
        {
            nav.SetDestination(transform.position);
            anim.SetFloat("Run", 0.0f);
            anim.SetFloat("Walk", 0f);
        }
	}
    void FollowPlayer()
    {
        nav.SetDestination(player.transform.position);
        anim.SetFloat("Walk", 1f);
        anim.SetFloat("Run", 2f);
    }
}
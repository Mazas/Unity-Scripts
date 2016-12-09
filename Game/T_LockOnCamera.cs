using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_LockOnCamera : MonoBehaviour {
    public Transform enemy;
    private Transform player;
    public bool targeting=false;
    private Vector3 center;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update () {
		if (targeting)
        {
            center = ((enemy.position - player.position) / 2.0f) + player.position;
            transform.LookAt(center);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position - new Vector3(player.transform.forward.x * 6, player.transform.forward.y - 3.0f, player.transform.forward.z * 6), 6);
        }
	}
    public void Target(Transform enemy)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Tadas_OOTCamera>().enabled = false;
        targeting = true;
        this.enemy = enemy;
    }
    public void RemoveTarget()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Tadas_OOTCamera>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Tadas_OOTCamera>().ReCenterCamera();
        targeting = false;
        enemy = null;
    }
    public void LookAtTarget()
    {
        player.transform.LookAt(enemy); //UNCOMMENT AFTER WE HAVE PLAYER CONTROLLER FOR COMBAT
    }
}

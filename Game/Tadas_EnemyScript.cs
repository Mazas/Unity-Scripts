using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Tadas_EnemyScript : MonoBehaviour {

    private GameObject player;
    private NavMeshAgent nav;
    private Animator anim;
    private float distance;
    private Vector3 myPosition;

    public AudioClip swordSound;
    public AudioClip enemyHowl1;
    public AudioClip enemyHowl2;
    private AudioSource source;
    private float accumulateTime = 0;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        myPosition = transform.position;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 2)
        {
            anim.SetBool("Run", false);
            nav.SetDestination(transform.position);
            anim.SetTrigger("attack_01");
            transform.LookAt(player.transform);

            accumulateTime += Time.deltaTime;
            //accumulateTime = (float)System.Math.Round(accumulateTime, 1);
            if (accumulateTime >= 1.33f)
            {
                float volume = Random.Range(0.5f, 1f);
                source.PlayOneShot(swordSound, volume);
                if (volume == 0.5f)
                {
                    source.PlayOneShot(enemyHowl1, volume);
                }
                else
                {
                    source.PlayOneShot(enemyHowl2, volume);
                }
                accumulateTime -= 1;
            }
        }
        else if (distance > 2 && distance < 10)
        {
            transform.LookAt(player.transform);
            nav.SetDestination(player.transform.position);
            anim.SetBool("Run", true);

        }
        else if (distance > 30)
        {
            if (Vector3.Distance(transform.position, myPosition) > 2)
            {
                anim.SetBool("Run", true);
                nav.SetDestination(myPosition);
            }
            else
            {
                anim.SetBool("Run", false);
                nav.SetDestination(transform.position);
            }
       }
    }
}


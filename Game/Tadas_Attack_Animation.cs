using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tadas_Attack_Animation : MonoBehaviour {

    private Animator anim;
    private int i = 1;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            anim.SetBool("Attack",true);
        }
        else
        {
            anim.SetBool("Attack",false);
        }
	}
    public void Die()
    {
        if (!anim.GetBool("Dead"))
        {
            anim.SetBool("Dead", true);
        }
    }
}

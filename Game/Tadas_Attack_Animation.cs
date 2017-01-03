using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tadas_Attack_Animation : MonoBehaviour
{

    private Animator anim;
    private CapsuleCollider weaponCollider;
    private GameObject[] weapons = new GameObject[3];
    private int currentWeapon = 0;
    public bool q1complete;
    public bool q2complete;
    void Start()
    {
        anim = GetComponent<Animator>();
        weapons[0] = GameObject.Find("cutter01");
        weapons[1] = GameObject.Find("sword_epic");
        weapons[2] = GameObject.Find("dagger_epic");
        foreach (GameObject weap in weapons)
        {
            weap.SetActive(false);
        }
        weapons[0].SetActive(true);
        weaponCollider = weapons[0].GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (GetCurrentWeapon()!="dagger")
            {
                weaponCollider.enabled = true;
                anim.SetBool("Attack", true);
            }
            else
            {
                weaponCollider.enabled = true;
                anim.SetBool("Dagger_Attack", true);
            }
        }
        else
        {
            weaponCollider.enabled = false;
            anim.SetBool("Attack", false);
            anim.SetBool("Dagger_Attack", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            if (GetCurrentWeapon()=="cutter"&& q1complete)
            {
                currentWeapon = 1;
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weaponCollider = weapons[1].GetComponent<CapsuleCollider>();
            }
            else if ((GetCurrentWeapon() == "sword" && q2complete) || (GetCurrentWeapon() == "cutter" && q2complete && !q1complete))
            {
                currentWeapon = 2;
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
                weaponCollider = weapons[2].GetComponent<CapsuleCollider>();
            }
            else
            {
                currentWeapon = 0;
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
                weapons[0].SetActive(true);
                weaponCollider = weapons[0].GetComponent<CapsuleCollider>();
            }
        }
    }
    public void Die()
    {
        if (!anim.GetBool("Dead"))
        {
            anim.SetBool("Dead", true);
        }
    }
    public string GetCurrentWeapon()
    {
        switch (weapons[currentWeapon].name){
            case "dagger_epic":
                return "dagger";
            case "cutter01":
                return "cutter";
            case "sword_epic":
                return "sword";
            default:
                return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //creates a new Stat object called health
    public Stat health;
    //Stores if player is in fire
    public bool onFire;
    //Stores if player is getting healed
    public bool healOn;

    //starts the healthbar
    private void Awake()
    {
        health.Initialize();
    }

    void Update()
    {
        // if player is taking Dmg his health decreases by one each frame
        if (onFire)
        {
            health.CurrentVal -= 1;
            onFire = false;
            if (health.CurrentVal <= 0)
            {
                Die();
            }
        }
        // if player is getting healed his health increases by one each frame
        if (healOn)
        {
            health.CurrentVal += 1;
            healOn = false;
        }
    }


    void OnTriggerStay(Collider other)
    {
        // Checks if player is standing in fire
        if (other.gameObject.name == "Fire")
        {
            onFire = true;
        }
        //Checks if player is standing in green healing stuff
        if (other.gameObject.name == "Heal")
        {
            healOn = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player_Weapon")
        {
            Debug.Log(other.collider.GetComponent<Weapon_Damage>().damage);
            TakeDamage(other.collider.GetComponent<Weapon_Damage>().damage);
        }
    }
    void TakeDamage(float damage)
    {
        health.CurrentVal -= damage;
        if (health.CurrentVal <= 0)
        {
           Die();
        }
    }
    public void Die()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        gameObject.GetComponent<Animator>().SetTrigger("die");
        Destroy(gameObject.GetComponent<Tadas_EnemyScript>());
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        CapsuleCollider[] colliders = GetComponentsInChildren<CapsuleCollider>();
        foreach (CapsuleCollider collider in colliders)
        {
            collider.enabled = false;
        }
    }
}

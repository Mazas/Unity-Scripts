using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn_Targeting : MonoBehaviour {

    public List<Transform> targets;
    public Transform selectedTarget;
    private Transform myTransform;
    private float distance;
    public float speed = 50f,h;
    private Animator anim;
    private bool isLockedOn;
    private bool idleLocked = true;
    private Rigidbody rb;
    // Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        targets = new List<Transform>();
        myTransform = transform;
        rb = GetComponent<Rigidbody>();
        AddAllEnemies();
    }


    void FixedUpdate()
    {
}
	// Update is called once per frame
	void Update () {

    

        if (Input.GetKeyDown(KeyCode.U))
        {
            TargetEnemy();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            selectedTarget = null;
        }
        
	}

    
    public void AddAllEnemies()
    {
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in gameobjects)
        {
         //       float lockOnDistance = (transform.position - enemy.transform.position).magnitude;
           //   if (lockOnDistance < 30) 
            {        
            AddTarget(enemy.transform);              
            }
        }
    }

    private void SortTargetsByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2)
        {

            return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
        });
 
        }
    
public void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            SortTargetsByDistance();
        selectedTarget = targets[0];
        
        }
        else 
        {
            int index = targets.IndexOf(selectedTarget);
            if (index < targets.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
                
            }
            selectedTarget = targets[index];
            isLockedOn = true;
        }
        
    }
  
    void SelectedTarget()
    {
        isLockedOn = true;
   /*     Transform name = selectedTarget.FindChild("EnemyName");
        if (name == null)
        {
            Debug.LogError("Could not find component"+ selectedTarget.name);
            return;
        }
       //name.GetComponent<Text>
    */}

    public void DeselectTarget()
    {
        //selectedTarget.FindChild("EnemyName").GetComponent<MeshRenderer>().enabled = false;
        selectedTarget = null;
        isLockedOn = false;
    }

    public void AddTarget(Transform enemy)
    {
        targets.Add(enemy);
    }
    public void RemoveTarget(Transform enemy)
    {
        targets.Remove(enemy);
    }
    public Transform getEnemy()
    {
        return selectedTarget;
    }
  public  void WalkForward()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        distance = Vector3.Distance(transform.position,selectedTarget.transform.position);
        if (distance > 1f)
        {
            idleLocked = false;
            anim.SetBool("CombatIdle", false);
            transform.Translate(Vector3.forward * (speed+2f) * Time.deltaTime, Space.Self);
            anim.SetBool("BattleForward",true);
        }
    }
 public   void RotateLeft()
    {
      
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        idleLocked = false;
        anim.SetBool("CombatIdle", false);
        distance = Vector3.Distance(transform.position, selectedTarget.transform.position);
        transform.LookAt(selectedTarget.position);
        transform.Translate(Vector3.left *(speed+2f) * Time.deltaTime, Space.Self);
        anim.SetTrigger("WalkLeft");
    }
 public   void RotateRight()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        idleLocked = false;
        anim.SetBool("CombatIdle", false);
        distance = Vector3.Distance(transform.position, selectedTarget.transform.position);
        transform.LookAt(selectedTarget.position);
        transform.Translate(Vector3.right * (speed+2f) * Time.deltaTime, Space.Self);
        anim.SetTrigger("WalkRight");
    }
    public void WalkBackwards()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        anim.SetBool("Walk_Back", true);
        transform.LookAt(selectedTarget.position);
        transform.Translate(Vector3.back * speed  * Time.deltaTime, Space.Self);
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Turn", h / 3 * 2);
    }
    public void RotateLeftForward()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        distance = Vector3.Distance(transform.position, selectedTarget.transform.position);
        if (distance > 1f)
        {
            idleLocked = false;
            anim.SetBool("CombatIdle", false);
            transform.Translate(Vector3.forward * (speed+1f) * Time.deltaTime, Space.Self);
            anim.SetBool("BattleForward", true);
            transform.LookAt(selectedTarget.position);
            transform.Translate(Vector3.left * (speed+1f) * Time.deltaTime, Space.Self);
            anim.SetTrigger("WalkLeft");
        }
    }
    public void RotateRightForward()
    {
        
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        distance = Vector3.Distance(transform.position, selectedTarget.transform.position);
        if (distance > 1f)
        {
            idleLocked = false;
            anim.SetBool("CombatIdle", false);
            transform.Translate(Vector3.forward * (speed+1f) * Time.deltaTime, Space.Self);
            anim.SetBool("BattleForward", true);
            transform.LookAt(selectedTarget.position);
            transform.Translate(Vector3.right * (speed+1f) * Time.deltaTime, Space.Self);
            
            anim.SetTrigger("WalkLeft");
        }
    }
    public void RotateLeftBackwards()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        anim.SetBool("Walk_Back", true);
        transform.LookAt(selectedTarget.position);
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.left * (speed) * Time.deltaTime, Space.Self);
        anim.SetTrigger("WalkLeft");
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Turn", h / 3 * 2);
    }
    public void RotateRightBackwards()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        anim.SetBool("Walk_Back", true);
        transform.LookAt(selectedTarget.position);
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.right * (speed) * Time.deltaTime, Space.Self);
        anim.SetTrigger("WalkRight");
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Turn", h / 3 * 2);
    }

    public bool getIsLockedOn()
    {
        return isLockedOn;
    }
public Transform getSelectedTarget()
    {
        return selectedTarget;
    }

}

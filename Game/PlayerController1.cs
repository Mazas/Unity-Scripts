using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {
    public float speed = 2000f;
    public GameObject lazer;
	private Rigidbody rb;
    private bool isOnFloor = true;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) {
            transform.Translate(Vector3.forward*speed*Time.deltaTime,Space.Self);
            transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0),speed*Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S)&&!(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))) {
            transform.Translate(Vector3.back*speed*Time.deltaTime, Space.Self);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), speed*Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 45, 0), speed*Time.fixedDeltaTime);
                transform.Translate(Vector3.forward * (speed/2) * Time.deltaTime, Space.Self);
                transform.Translate(Vector3.right * (speed / 2) * Time.deltaTime, Space.Self);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 135, 0),speed* Time.fixedDeltaTime);
                transform.Translate(Vector3.back * (speed/2) * Time.deltaTime, Space.Self);
                transform.Translate(Vector3.right * (speed/2) * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), speed*Time.fixedDeltaTime);
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
            }
        }
        if (Input.GetKey(KeyCode.A)) {
            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -45, 0), speed*Time.fixedDeltaTime);
                transform.Translate(Vector3.forward * (speed / 2) * Time.deltaTime, Space.Self);
                transform.Translate(Vector3.left * (speed / 2) * Time.deltaTime, Space.Self);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -135, 0), speed*Time.fixedDeltaTime);
                transform.Translate(Vector3.back * (speed / 2) * Time.deltaTime, Space.Self);
                transform.Translate(Vector3.left * (speed/2) * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), speed*Time.fixedDeltaTime);
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isOnFloor) {
			rb.AddForce (Vector3.up*350);
            isOnFloor = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Instantiate(lazer,transform.position,new Quaternion(0,0,0,0));

        }
	}
    void OnCollisionEnter()
    {
        isOnFloor = true;
    }
}

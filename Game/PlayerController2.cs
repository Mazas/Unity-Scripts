using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Player Controller with animation triggers
 */
public class PlayerController2 : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private bool isOnFloor = true;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnFloor)
        {
            if ((Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
                anim.SetBool("IsWalking", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.fixedDeltaTime);
            }
            if ((Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
                anim.SetBool("IsWalking", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), speed * Time.fixedDeltaTime);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 45, 0), speed * Time.fixedDeltaTime);
                    transform.Translate(Vector3.forward * (speed / 2) * Time.deltaTime, Space.World);
                    transform.Translate(Vector3.right * (speed / 2) * Time.deltaTime, Space.World);
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 135, 0), speed * Time.fixedDeltaTime);
                    transform.Translate(Vector3.back * (speed / 2) * Time.deltaTime, Space.World);
                    transform.Translate(Vector3.right * (speed / 2) * Time.deltaTime, Space.World);
                }
                else
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), speed * Time.fixedDeltaTime);
                    transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
                }
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -45, 0), speed * Time.fixedDeltaTime);
                    transform.Translate(Vector3.forward * (speed / 2) * Time.deltaTime, Space.World);
                    transform.Translate(Vector3.left * (speed / 2) * Time.deltaTime, Space.World);
                }
                else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -135, 0), speed * Time.fixedDeltaTime);
                    transform.Translate(Vector3.back * (speed / 2) * Time.deltaTime, Space.World);
                    transform.Translate(Vector3.left * (speed / 2) * Time.deltaTime, Space.World);
                }
                else
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), speed * Time.fixedDeltaTime);
                    transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
            {
                rb.AddForce(Vector3.up*200);
                anim.SetBool("OnGround", false);
                isOnFloor = false;
            }
            if (!IsMovementKeyPressed()&&isOnFloor)
            {
                anim.SetBool("IsWalking",false);
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag.Equals("Floor"))
        {
            isOnFloor = true;
           // anim.SetBool("OnGround", true);
        }
        else return;
    }
    bool IsMovementKeyPressed()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            return true;
        }
        return false;
    }
}

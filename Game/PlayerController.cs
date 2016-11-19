using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private bool isOnFloor = true;
    private Animator anim;
    private GameObject mainCamera;
    private bool reverse;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void FixedUpdate()
    {
        reverse = mainCamera.GetComponent<OOTCamera>().IsCameraReversed(reverse);
        if (isOnFloor)
        {
            if (!reverse)
            {
                if ((Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                if ((Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 45, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 135, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -45, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -135, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                }
            }
            else
            {
                if ((Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                if ((Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -135, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -45, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 135, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 45, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else
                    {
                        anim.SetBool("IsWalking", true);
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
            {
                rb.AddForce(Vector3.up * 200);
                isOnFloor = false;
            }
            if (!IsMovementKeyPressed() && isOnFloor)
            {
                anim.SetBool("IsWalking", false);
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag.Equals("Floor"))
        {
            isOnFloor = true;
        }
        else return;
    }
   public bool IsMovementKeyPressed()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            return true;
        }
        return false;
    }
    void Go()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

    }
}
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private bool isOnFloor = true;
    private Animator anim;

    private float forward;
    private float back;
    private float left;
    private float right;
    private float leftForward;
    private float rightBack;
    private float leftBack;
    private float rightForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isOnFloor)
        {
            if ((Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
            {
                anim.SetBool("IsWalking", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, forward, 0), speed * Time.fixedDeltaTime);
                Go();
            }
            if ((Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
            {
                anim.SetBool("IsWalking", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, back, 0), speed * Time.fixedDeltaTime);
                Go();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rightForward, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rightBack, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                else
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, right, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, leftForward, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, leftBack, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                else
                {
                    anim.SetBool("IsWalking", true);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, left, 0), speed * Time.fixedDeltaTime);
                    Go();
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
    public void NormalControls()
    {
        this.forward = 0;
        this.back = 180;
        this.right = 90;
        this.left = -90;
        this.leftBack = -135;
        this.leftForward = -45;
        this.rightBack = 135;
        this.rightForward = 45;
        Debug.Log("Normal");
    }
    public void ReversedControls()
    {
        this.forward = 180;
        this.back = 0;
        this.right = -90;
        this.left = 90;
        this.leftBack = 45;
        this.leftForward = 135;
        this.rightBack = -45;
        this.rightForward = -135;
        Debug.Log("Reversed!");
    }
    public void LeftControls()
    {
        this.forward = -90;
        this.back = 90;
        this.right = 0;
        this.left = 180;
        this.leftBack = 45;
        this.leftForward = -45;
        this.rightBack = 135;
        this.rightForward = -135;
        Debug.Log("Left!");
    }
    public void RightControls()
    {
        this.forward = 90;
        this.back = -90;
        this.right = 180;
        this.left = 0;
        this.leftBack = -45;
        this.leftForward = 45;
        this.rightBack = -135;
        this.rightForward = 135;
        Debug.Log("Right!");
    }
}
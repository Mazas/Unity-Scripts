using UnityEngine;

public class Tadas_PlayerController : MonoBehaviour
{
    public float speed = 1f;
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
    private float h;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        NormalControls();
    }

    void FixedUpdate()
    {
        if (isOnFloor)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (transform.rotation.eulerAngles.y >= 180)
                {
                    back = transform.rotation.eulerAngles.y - 180;
                }
                else
                {
                    back = transform.rotation.eulerAngles.y + 180;
                }
            }
            if ((Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + forward, 0), speed * Time.fixedDeltaTime);
                Go();
            }
            if ((Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
            {
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, back, 0), speed * Time.fixedDeltaTime);
                GoBack();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + rightForward, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + leftBack, 0), (speed/2) * Time.fixedDeltaTime);
                    GoBack();
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + right, 0), speed * Time.fixedDeltaTime);
                    //Go();
                }
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + leftForward, 0), speed * Time.fixedDeltaTime);
                    Go();
                }
                else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + rightBack, 0), (speed/2) * Time.fixedDeltaTime);
                    GoBack();
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + left, 0), speed * Time.fixedDeltaTime);
                   // Go();
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
            {
                rb.AddForce(Vector3.up * 150);
                isOnFloor = false;
                anim.SetBool("Jump",true);
            }
            if (!IsMovementKeyPressed() && isOnFloor)
            {
                anim.SetBool("Walk_Back",false);
                anim.SetFloat("Turn", 0f);
                anim.SetFloat("Run", 0f);
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
        anim.SetBool("Walk_Back", false);

        anim.SetFloat("Run", 0.5f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Turn", h);

    }
    void GoBack()
    {
        anim.SetBool("Walk_Back", true);
        transform.Translate(Vector3.back * (speed/2) * Time.deltaTime, Space.Self);
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Turn", h);
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
}
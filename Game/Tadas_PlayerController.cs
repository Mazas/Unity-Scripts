using UnityEngine;

public class Tadas_PlayerController : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody rb;
    public bool isOnFloor = true;
    private Animator anim;
    private float h;
    private T_LockOnCamera cameraScript;

    private bool paused = false;
    private GameObject pauseMenu;

    private LockOn_Targeting target;

    void Start()
    {
        target = GetComponent<LockOn_Targeting>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        pauseMenu.SetActive(false);
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<T_LockOnCamera>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    void FixedUpdate()
    {
        if (!target.getIsLockedOn())
        {
            if (isOnFloor)
            {
                if ((Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
                {
                    Go();
                }
                if ((Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) || (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
                {
                    GoBack();
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + -90, 0), (speed / 3 * 2) * Time.fixedDeltaTime);
                        GoBack();
                    }
                    else if (cameraScript.targeting)
                    {
                        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
                        anim.SetTrigger("WalkRight");

                    }
                    else
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0), speed * Time.fixedDeltaTime);
                    }
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + -90, 0), speed * Time.fixedDeltaTime);
                        Go();
                    }
                    else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0), (speed / 3 * 2) * Time.fixedDeltaTime);
                        GoBack();
                    }
                    else if (cameraScript.targeting)
                    {
                        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
                        anim.SetTrigger("WalkLeft");
                    }
                    else
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + -90, 0), speed * Time.fixedDeltaTime);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
                {
                    //rb.AddForce(Vector3.up * 150);
                    // isOnFloor = false;
                    anim.SetBool("Jump", true);
                }

                if (!IsMovementKeyPressed() && isOnFloor)
                {
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    anim.SetBool("Walk_Back", false);
                    anim.SetFloat("Turn", 0f);
                    anim.SetFloat("Run", 0f);
                    anim.SetBool("Dagger_Run", false);
                    anim.SetBool("WalkLeft", false);
                    anim.SetBool("WalkRight", false);
                    anim.SetBool("CombatIdle", false);
                    anim.SetBool("BattleForward", false);
                }
            }
        }
        if (target.getIsLockedOn() == true)
        {
            if (isOnFloor)
            {
                transform.LookAt(target.getSelectedTarget());
                if (Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) || Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
                {
                    target.WalkForward();
                }
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
                {
                    {
                        target.RotateLeftForward();
                    }
                   
                }
                if (Input.GetKey(KeyCode.A)&& !(Input.GetKey(KeyCode.W)||(Input.GetKey(KeyCode.S)))||Input.GetKey(KeyCode.LeftArrow)&&!(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)))
                {
                    target.RotateLeft();
                }
                if(Input.GetKey(KeyCode.D)&&Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.RightArrow)&&Input.GetKey(KeyCode.UpArrow))
                {
                    target.RotateRightForward();
                }
                if ((Input.GetKey(KeyCode.D)&&!(Input.GetKey(KeyCode.W)||(Input.GetKey(KeyCode.S)))||Input.GetKey(KeyCode.RightArrow)&&!(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow))))
                {
                    target.RotateRight();
                }
                if ((Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) ||( Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))))
                {
                    target.WalkBackwards();
                }
                if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.LeftArrow)&&Input.GetKey(KeyCode.DownArrow))){
                    target.RotateLeftBackwards();
                }
                if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))|| (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)))
                {
                    target.RotateRightBackwards();
                }
            }
            if (!IsMovementKeyPressed() && isOnFloor)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                anim.SetBool("Walk_Back", false);
                anim.SetFloat("Turn", 0f);
                anim.SetFloat("Run", 0f);
                anim.SetBool("Dagger_Run", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", false);
                anim.SetBool("BattleForward", false);
                anim.SetBool("CombatIdle", true);
            }

        }
        if (Input.GetKey(KeyCode.I))
        {
            target.DeselectTarget();
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
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        anim.SetBool("Walk_Back", false);
        if (GetComponent<Tadas_Attack_Animation>().GetCurrentWeapon() == "dagger")
        {
            anim.SetBool("Dagger_Run", true);
        }
        else
        {
            anim.SetFloat("Run", 0.5f);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Turn", h / 3 * 2);
    }

    void GoBack()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        anim.SetBool("Walk_Back", true);
        transform.Translate(Vector3.back * (speed / 3 * 2) * Time.deltaTime, Space.Self);
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Turn", h / 3 * 2);
    }

    public void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
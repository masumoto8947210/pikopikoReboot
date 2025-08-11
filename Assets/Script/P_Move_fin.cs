using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Move_fin : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float gravity;
    [SerializeField] public float jumpSpeed;
    [SerializeField] public float highjumpSpeed;
    [SerializeField] public float lowjumpSpeed;
    [SerializeField] public float jumpHeight;
    [SerializeField] public float jumpLimitTime;
    [SerializeField] public float highjumpHeight;
    [SerializeField] public float highjumpLimitTime;
    [SerializeField] public float lowjumpHeight;
    [SerializeField] public float lowjumpLimitTime;
    [SerializeField] public GroundCheck ground;
    [SerializeField] public GroundCheck head;
    [SerializeField] public AnimationCurve dashCurve;
    [SerializeField] public AnimationCurve jumpCurve;
    [SerializeField] public AnimationCurve highjumpCurve;
    [SerializeField] public AnimationCurve lowjumpCurve;
    [SerializeField] public float stepOnRate;

    private Animator anim = null;
    private Rigidbody rb = null;
    private BoxCollider boxcol = null;
    private AudioSource source;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private bool isHighJump = false;
    private bool isLowJump = false;
    private bool isGrab = false;
    private bool isGrabJump = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxcol = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = ground.IsGround();
        isHead = head.IsGround();
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();

        if (xSpeed == 0)
        {
            anim.SetBool("walk", false);
        }
        else
        {
            anim.SetBool("walk", true);
        }


        rb.linearVelocity = new Vector3(xSpeed, ySpeed, 0.0f);
    }

    private float GetYSpeed()
    {
        float ySpeed = -gravity;

        if (isGrab)
        {
            ySpeed = 0f;
        }


        if (isHighJump)
        {

            bool canHeight = jumpPos + highjumpHeight > transform.position.y;
            bool canTime = highjumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = highjumpSpeed;
                jumpTime += Time.deltaTime;
                anim.SetBool("jump", true);
            }
            else
            {
                isHighJump = false;
                jumpTime = 0.0f;
            }
        }

        else if (isLowJump)
        {

            bool canHeight = jumpPos + lowjumpHeight > transform.position.y;
            bool canTime = lowjumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                anim.SetBool("jump", true);
                ySpeed = lowjumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isLowJump = false;
                jumpTime = 0.0f;
            }

        }
        else if (isJump && !isGrab)
        {
            bool pushUpKey = Input.GetKey(KeyCode.Space);
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
                isGrab = false;
                isGrabJump = false;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
                isGrab = false;
            }
        }
     
        else if (isGround || isGrabJump)
        {
            isHighJump = false;
            isLowJump = false;

            if (Input.GetKey(KeyCode.Space))
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJump = true;
                isGrabJump = false;
                isGrab = false;
                jumpTime = 0.0f;
                anim.SetBool("jump", true);
            }
            else
            {
                isJump = false;
                anim.SetBool("jump", false);
            }
        }




        if (isJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        if (isHighJump)
        {
            ySpeed *= highjumpCurve.Evaluate(jumpTime);
        }
        if (isLowJump)
        {
            ySpeed *= lowjumpCurve.Evaluate(jumpTime);
        }


        return ySpeed;
    }

    private float GetXSpeed()
    {
        float xSpeed = 0.0f;
        if (Input.GetKey(KeyCode.J) && !isGrab)
        {
            dashTime += Time.deltaTime;
            xSpeed = speed;
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKey(KeyCode.F) && !isGrab)
        {
            dashTime += Time.deltaTime;
            xSpeed = -speed;
            this.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        if (Input.GetKey(KeyCode.F) && xSpeed > 0 && !isGrab)
        {
            dashTime = 0.0f;
            dashTime += Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.J) && xSpeed < 0 && !isGrab)
        {
            dashTime = 0.0f;
            dashTime += Time.deltaTime;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        return xSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Kinoko")
        {
            float stepOnHeight = (boxcol.size.y * (stepOnRate / 100f));

            float judgePos = transform.position.y - (boxcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    isHighJump = false;
                    isLowJump = false;
                    if (Input.GetKey(KeyCode.Space))
                    {
                        jumpPos = transform.position.y;
                        isHighJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }

                    else
                    {
                        jumpPos = transform.position.y;
                        isLowJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rope")
        {
            transform.position = new Vector3(other.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
            isJump = false;
            isHighJump = false;
            isLowJump = false;
            isGrab = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Rope")
        {

            if (!Input.GetKey(KeyCode.Space) || !isJump)
            {
                isGrabJump = true;
            }



        }

        if (other.gameObject.tag == "Houseki")
        {
            source.Play();
        }
    }


}


    


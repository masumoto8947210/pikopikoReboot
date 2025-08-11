using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piko_move : MonoBehaviour
{
    [Header("�ړ����x")] public float speed;
    [Header("�d��")] public float gravity;
    [Header("�W�����v���x")] public float jumpSpeed;
    [Header("��W�����v���x")] public float highjumpSpeed;
    [Header("���W�����v���x")] public float lowjumpSpeed;
    [Header("�W�����v���鍂��")] public float jumpHeight;
    [Header("�W�����v���钷��")] public float jumpLimitTime;
    [Header("��W�����v���鍂��")] public float highjumpHeight;
    [Header("��W�����v���钷��")] public float highjumpLimitTime;
    [Header("���W�����v���鍂��")] public float lowjumpHeight;
    [Header("���W�����v���钷��")] public float lowjumpLimitTime;
    [Header("�ڒn����")] public GroundCheck ground;
    [Header("�V�䔻��")] public GroundCheck head;
    [Header("�_�b�V���̑����\��")] public AnimationCurve dashCurve;
    [Header("�W�����v�̑����\��")] public AnimationCurve jumpCurve;
    [Header("��W�����v�̑����\��")] public AnimationCurve highjumpCurve;
    [Header("�W�����v�̑����\��")] public AnimationCurve lowjumpCurve;
    [Header("���݂�����̍����̊���(%)")] public float stepOnRate;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = ground.IsGround();
        isHead = head.IsGround();
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();


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
        //�n�ʂɂ���Ƃ�
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
      
            }
        }
        //�W�����v��



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
        }
        else if (Input.GetKey(KeyCode.F) && !isGrab)
        {
            dashTime += Time.deltaTime;
            xSpeed = -speed;
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


    


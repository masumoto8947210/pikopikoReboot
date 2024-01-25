using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class P_Move : MonoBehaviour
{
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("大ジャンプする高さ")] public float highjumpHeight;
    [Header("大ジャンプする長さ")] public float highjumpLimitTime;
    [Header("小ジャンプする高さ")] public float lowjumpHeight;
    [Header("小ジャンプする長さ")] public float lowjumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;

    private Animator anim = null;
    private Rigidbody rb = null;
    private BoxCollider boxcol = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private bool isHighJump = false;
    private bool isLowJump = false;
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

        rb.velocity = new Vector3(xSpeed, ySpeed, 0.0f);
    }
    private float GetYSpeed()
    {
        float ySpeed = -gravity;

        if (isHighJump)
        {

　　　      bool canHeight = jumpPos + highjumpHeight > transform.position.y;
            bool canTime = highjumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
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
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isLowJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; 
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            bool pushUpKey = Input.GetKey(KeyCode.Space);
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isHighJump || isLowJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }













    private float GetXSpeed()
    {
        float xSpeed = 0.0f;
        if (Input.GetKey(KeyCode.J))
        {
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (Input.GetKey(KeyCode.F))
        {       
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        if(Input.GetKey(KeyCode.F) && xSpeed > 0 )
        {
            dashTime = 0.0f;
        }
        else if (Input.GetKey(KeyCode.J) && xSpeed < 0)
        {
            dashTime = 0.0f;
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
                   if(Input.GetKey(KeyCode.Space))
                    {
                        jumpPos = transform.position.y;
                        isHighJump = true;
                        isJump = false;
                    }
                    
                   else
                    {
                        jumpPos = transform.position.y;
                        isLowJump = true;
                        isJump = false;
                    }
                }
               
            }
        }
    }
}

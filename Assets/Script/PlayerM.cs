using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerM : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] private GameObject Mono;
    [SerializeField] private float wtime;
    RockMove script;
    private bool PMove = true;

    private Rigidbody rb;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        script = Mono.GetComponent<RockMove>();
    }

    void Update()
    {
    //    if (script.RMoving == true || script.LMoving == true)
      //      StartCoroutine("Wait"); //�R���[�`���u���v


       // if (Input.GetKeyDown("o"))
        //{
          //  script.RMoving = true;
        //}

            if (PMove)
        {
            // ���E�̈ړ�
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, verticalInput * moveSpeed);
            rb.linearVelocity = movement;

            // �W�����v
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }


        }
    }


void OnCollisionEnter(Collision collision)
{
    // �n�ʂɐG�ꂽ��W�����v�\�ɂ���
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
}

void OnCollisionExit(Collision collision)
{
    // �n�ʂ��痣�ꂽ��W�����v�s�ɂ���
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
    }
}

private IEnumerator Wait()
{
    PMove = false;
    yield return new WaitForSeconds(1);
    PMove = true;
}
}


using UnityEngine;

public class RockMove : MonoBehaviour
{
    public float maxDistance = 3.0f;
    public double GravityDistance = 0.1; 
    private Vector3 originalPosition;
    private Rigidbody rb;
    public bool PlayerTouch = false;
    public float additionalGravity = 10f; // �ǉ��̏d�͂̋���
    private Vector3 firstPosition;
    public float maxResetPosition;
    public float minResetPosition;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        originalPosition = transform.position;
        firstPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(originalPosition, transform.position) >= maxDistance)
        {
            // �ړ��������̋����ړ������畨�����Z���~
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
       if (Mathf.Abs(transform.position.y - originalPosition.y ) >= GravityDistance )
        rb.AddForce(Vector3.down * additionalGravity, ForceMode.Acceleration);

        //PlayerTouch = false;

        Vector2 currentPlayerPosition = new Vector2(player.transform.position.x, player.transform.position.y);

        //ResetPosition�O�ɏo��ƈʒu������
       if (currentPlayerPosition.x > maxResetPosition || currentPlayerPosition.x < minResetPosition) 
       transform.position = firstPosition;


    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerTouch = true;
        }
    }

}

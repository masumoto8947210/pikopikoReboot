using UnityEngine;

public class RockMove : MonoBehaviour
{
    public float pushForce = 2.0f;
    public float maxDistance = 3.0f;
    public double GravityDistance = 0.1; 
    private Vector3 originalPosition;
    private Rigidbody rb;
    private bool PlayerTouch = false;
    public float additionalGravity = 10f; // í«â¡ÇÃèdóÕÇÃã≠Ç≥

    private void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(originalPosition, transform.position) >= maxDistance)
        {
            // à⁄ìÆíÜÇ©Ç¬àÍíËÇÃãóó£à⁄ìÆÇµÇΩÇÁï®óùââéZÇí‚é~
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
       if (Mathf.Abs(transform.position.y - originalPosition.y ) >= GravityDistance && !PlayerTouch)
            rb.AddForce(Vector3.down * additionalGravity, ForceMode.Acceleration);
        PlayerTouch = false;

    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerTouch = true;
        }
    }

}

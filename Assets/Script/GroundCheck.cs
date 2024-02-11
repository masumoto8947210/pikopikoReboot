using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    private bool isStepSibafu;
    private bool isStepRock;
    private bool isStaySibafu;
    private bool isStayRock;
    // Start is called before the first frame update
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

     

        

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGround;

    }
    public bool IsStepSibafu()
    {
        if (isStaySibafu)
        {
            isStepSibafu = true;
        }
        else
        {
            isStepSibafu = false;
        }

        isStaySibafu = false;
        return isStepSibafu;
    }

    public bool IsStepRock()
    {
        if (isStayRock)
        {
            isStepRock = true;
        }
        else
        {
            isStepRock = false;
        }

        isStayRock = false;
        return isStepRock;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Sibafu" || collision.tag == "Rock")
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Sibafu" || collision.tag == "Rock")
        {
            isGroundStay = true;
        }

        if (collision.tag == "Sibafu")
        {
            isStaySibafu = true;

        }

        if (collision.tag == "Rock")
        {
            isStayRock = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Sibafu" || collision.tag == "Rock")
        {
            isGroundExit = true;
        }
    }
}

using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            GetComponent<SliderJoint2D>().useMotor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            GetComponent<SliderJoint2D>().useMotor = false;
        }
    }
}

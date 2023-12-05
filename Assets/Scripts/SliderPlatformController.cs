using UnityEngine;

public class SliderPlatformController : MonoBehaviour
{
    [SerializeField] private SliderJoint2D sliderPlatformJoint2D;
    private JointMotor2D sliderPlatformMotor;

    private void Start()
    {
        sliderPlatformMotor = sliderPlatformJoint2D.motor;
    }

    private void Update()
    {
        if (sliderPlatformJoint2D.limitState==JointLimitState2D.LowerLimit)
        {
            sliderPlatformMotor.motorSpeed = 2;
            sliderPlatformJoint2D.motor = sliderPlatformMotor;
        }

        if (sliderPlatformJoint2D.limitState == JointLimitState2D.UpperLimit)
        {
            sliderPlatformMotor.motorSpeed = -2;
            sliderPlatformJoint2D.motor = sliderPlatformMotor;
        }
    }
}

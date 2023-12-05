using UnityEngine;

public class SawRotation : MonoBehaviour
{
    private Quaternion sawRotation;

    private void Update()
    {
        sawRotation=Quaternion.AngleAxis(1,new Vector3(0,0,1));
        transform.rotation*=sawRotation;
    }
}

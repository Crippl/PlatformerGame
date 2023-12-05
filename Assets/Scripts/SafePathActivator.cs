using UnityEngine;

public class SafePathActivator : MonoBehaviour
{
    [SerializeField] private GameObject activatorNotice;
    [SerializeField] private GameObject safePathEffector;
    private Animator activatorAnimator;

    private void Start()
    {
        activatorAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && activatorNotice.activeSelf)
        {
            safePathEffector.SetActive(true);
            activatorNotice.SetActive(false);
            activatorAnimator.SetBool("isActive", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activatorAnimator.GetBool("isActive") == false)
        {
            activatorNotice.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activatorNotice.SetActive(false);
    }

}

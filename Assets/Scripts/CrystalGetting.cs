using UnityEngine;

public class CrystalGetting : MonoBehaviour
{
    [SerializeField] private GameObject crystalObject;
    private Animator crystalObjectAnimator;

    private void Start()
    {
        crystalObjectAnimator = crystalObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            crystalObjectAnimator.SetBool("CrystalGetted", true);
            collision.GetComponent<PlayerHUD>().CrystalsGetted();
            DestroyBonus();
        }
    }

    private void DestroyBonus()
    {
        Destroy(gameObject, 1f);
    }
}

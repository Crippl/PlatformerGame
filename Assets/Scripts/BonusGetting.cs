using UnityEngine;

public class BonusGetting : MonoBehaviour
{
    [SerializeField] private GameObject bonusObject;
    private Animator bonusObjectAnimator;

    private void Start()
    {
        bonusObjectAnimator=bonusObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            bonusObjectAnimator.SetBool("BonusGetted", true);
            collision.GetComponent<PlayerHUD>().BonusGetted();
            DestroyBonus();
        }
    }

    private void DestroyBonus()
    {
        Destroy(gameObject, 1f);
    }
}

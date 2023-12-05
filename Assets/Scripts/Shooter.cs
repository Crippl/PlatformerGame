using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;
    private Animator heroAnimator;

    private void Awake()
    {
        heroAnimator = GetComponent<Animator>();
    }

    public void Shoot(float direction)
    {
        if (heroAnimator.GetBool("isAttacks") == false)
        {
            GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
            heroAnimator.SetBool("isAttacks", true);

            if (direction >= 0)
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
            }
            else
            {
                currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
            }

            Destroy(currentBullet, 1);
        }
    }

    public void AttackToggle()
    {
        heroAnimator.SetBool("isAttacks", false);
    }
}

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    private Rigidbody2D enemyRigidbody2D;

    private void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        enemyRigidbody2D.velocity = Vector2.left * enemySpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRestriction"))
        {
            enemySpriteRenderer.flipX = !enemySpriteRenderer.flipX;
            enemySpeed *= -1;
        }
    }
}

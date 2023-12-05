using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private GameObject hero;
    private PlayerHUD playerHUD;
    private Image healthBar;
    private float currentHealth;
    private bool isAlive;

    private void Awake()
    {
        playerHUD=hero.GetComponent<PlayerHUD>();
        healthBar=Instantiate(healthBarPrefab,gameObject.transform).transform.Find("HealthBarImage").GetComponent<Image>();
        currentHealth = maxHealth;
        isAlive = true;
    }

    private void Update()
    {
        healthBar.fillAmount = currentHealth/maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (CheckIsAlive() == false)
        {
            if (gameObject.GetComponent<PlayerMovement>())
            {
                GetComponent<Animator>().SetBool("isDead", true);
            }
            else
            {
                Destroy(gameObject);
                playerHUD.EnemyKilled();
            }
        }
    }

    public bool CheckIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }
        return isAlive;
    }
}

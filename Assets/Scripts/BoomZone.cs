using UnityEngine;

public class BoomZone : MonoBehaviour
{
    [SerializeField] private Transform boomPointPosition;
    [SerializeField] private GameObject BoomEffectorPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            Destroy(Instantiate(BoomEffectorPrefab, boomPointPosition),0.5f);
        }
    }
}

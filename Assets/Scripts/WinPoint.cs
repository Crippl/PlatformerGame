using System.Collections;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    private Animator winPointAnimator;

    private void Start()
    {
        winPointAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHUD>().CanWin() == true)
        {
            winPointAnimator.SetBool("isWin", true);
            StartCoroutine(WinDelay());
        }
    }

    private IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(4);
        sceneController.YouWin();
    }
}

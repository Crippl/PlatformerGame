using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstCutsceneCamera;
    [SerializeField] private CinemachineVirtualCamera secondCutsceneCamera;
    [SerializeField] private CinemachineVirtualCamera thirdCutsceneCamera;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cutsceneCanvas;
    [SerializeField] private TMP_Text cutsceneText;
    private PlayerInput playerInput;
    private string firstPhrase = "You need activate this";
    private string secondPhrase = "And this";
    private string thirdPhrase = "To get to the crystal";

    private void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
        StartCoroutine(PhaseOneCutscene());
        StartCoroutine(PhaseTwoCutscene());
        StartCoroutine(PhaseThreeCutscene());
        StartCoroutine(EndCutscene());
    }

    private IEnumerator PhaseOneCutscene()
    {
        yield return new WaitForSeconds(1);
        playerInput.TurnOffControl();
        firstCutsceneCamera.Priority = virtualCamera.Priority + 1;
        cutsceneCanvas.SetActive(true);
        cutsceneText.text = firstPhrase;
    }

    private IEnumerator PhaseTwoCutscene()
    {
        yield return new WaitForSeconds(4);
        secondCutsceneCamera.Priority = firstCutsceneCamera.Priority + 1;
        cutsceneText.text = secondPhrase;
    }

    private IEnumerator PhaseThreeCutscene()
    {
        yield return new WaitForSeconds(7);
        thirdCutsceneCamera.Priority = secondCutsceneCamera.Priority + 1;
        cutsceneText.text = thirdPhrase;
    }

    private IEnumerator EndCutscene()
    {
        yield return new WaitForSeconds(11);
        virtualCamera.Priority=thirdCutsceneCamera.Priority + 1;
        cutsceneCanvas.SetActive(false);
        playerInput.TurnOnControll();
    }
}

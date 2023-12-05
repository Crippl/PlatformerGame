using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text bonusesCountText;
    [SerializeField] private TMP_Text bonusesCountOnWinText;
    [SerializeField] private TMP_Text crystalsCountText;
    [SerializeField] private TMP_Text enemyKilledCountText;
    [SerializeField] private TMP_Text enemyKilledCountOnWinText;
    [SerializeField] private GameObject activatorNotice;
    [SerializeField] private TMP_Text totalScoreOnWinText;
    [SerializeField] private TMP_Text currentLevelScoreText;

    private int bonusesCount;
    private int crystalsCount;
    private int enemyKilledCount;
    private int currentLevelScore;
    private static int totalScore;
    private int bonusesMulti;
    private int enemyKilledMulti;

    private void Start()
    {
        currentLevelScore = 0;
        bonusesCount = 0;
        crystalsCount = 0;
        enemyKilledCount = 0;
        bonusesMulti = 100;
        enemyKilledMulti = 50;
    }
    private void Update()
    {
        totalScoreOnWinText.text = totalScore.ToString();
    }

    public void BonusGetted()
    {
        bonusesCount++;
        bonusesCountText.text = bonusesCount.ToString();
    }

    public void CrystalsGetted()
    {
        crystalsCount++;
        crystalsCountText.text = crystalsCount.ToString();
    }

    public void EnemyKilled()
    {
        enemyKilledCount++;
        enemyKilledCountText.text=enemyKilledCount.ToString();
    }

    public bool CanWin()
    {
        if (crystalsCount > 0)
        {
            return true;
        }
        else return false;
    }

    public void ShowNotice()
    {
        activatorNotice.SetActive(true);
    }

    public void HideNotice()
    {
        activatorNotice.SetActive(false);
    }

    public bool NoticeIsActive()
    {
        return activatorNotice.activeSelf;
    }

    public void LevelScoreSumm()
    {
        bonusesCountOnWinText.text = bonusesCountText.text;
        enemyKilledCountOnWinText.text=enemyKilledCountText.text;
        currentLevelScore =currentLevelScore +(bonusesCount * bonusesMulti) + (enemyKilledCount * enemyKilledMulti);
        currentLevelScoreText.text = currentLevelScore.ToString();
    }

    public void TotalScoreSumm()
    {
        totalScore +=currentLevelScore;
    }

    public void MainMenuStartGame()
    {
        totalScore = 0;
    }
}

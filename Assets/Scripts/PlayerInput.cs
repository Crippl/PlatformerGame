using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
[RequireComponent (typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    public const string HorizontalAxis = "Horizontal";
    public const string VerticalAxis = "Vertical";
    public const string JumpButton = "Jump";
    public const string Fire_1 = "Fire1";
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private Health playerHealth;
    private bool isPlayerControl;

    private void Start()
    {
        isPlayerControl = true;
    }
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter=GetComponent<Shooter>();
        playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        if (playerHealth.CheckIsAlive() == true && isPlayerControl)
        {
            float horizontalDirection = Input.GetAxis(HorizontalAxis);
            bool isJumpButtonPressed = Input.GetButtonDown(JumpButton);

            if (Input.GetButtonDown(Fire_1))
            {
                shooter.Shoot(horizontalDirection);
            }

            playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        }
    }

    public void TurnOffControl()
    {
        isPlayerControl = false;
    }

    public void TurnOnControll()
    {
        isPlayerControl = true;
    }
}

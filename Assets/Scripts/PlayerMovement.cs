using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float playerSpeed;

    [Header("Settings")]
    [SerializeField] private GameObject groundColliderObject;
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;

    [Header("Other")]
    [SerializeField] private PortalDictionary playerPortalDictionary;

    private Transform groundColliderTransform;
    private SpriteRenderer heroSpriteRenderer;
    private bool heroLooksRight = true;
    private Animator heroAnimator;
    private Rigidbody2D playerRigidbody2D;
    private PlayerHUD playerHUD;
    private Transform teleportationPoint;

    private void Awake()
    {
        groundColliderTransform = groundColliderObject.transform;
        playerHUD = GetComponent<PlayerHUD>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        heroAnimator=GetComponent<Animator>();
        heroSpriteRenderer=GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerHUD.NoticeIsActive())
        {
            Teleportation();
        }
    }

    private void FixedUpdate()
    {

        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded=Physics2D.OverlapCircle(overlapCirclePosition,jumpOffset,groundMask);
        if (isGrounded )
        {
            heroAnimator.SetBool("isOnTheGround", true);
            heroAnimator.SetBool("isJumping", false);
        }
        else
        {
            heroAnimator.SetBool("isOnTheGround", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerPortalDictionary.ContainsKeyInDictionary(collision.gameObject))
        {
            teleportationPoint = playerPortalDictionary.GetValue(collision.gameObject);
            playerHUD.ShowNotice();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerPortalDictionary.ContainsKeyInDictionary(collision.gameObject))
        {
            playerHUD.HideNotice();
        }
    }

    public void Move(float direction,bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }

        if (Mathf.Abs(direction) >0.01f)
        {
            HorizontalMovement(direction);
            heroAnimator.SetFloat("Speed",Mathf.Abs(direction));
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpForce);
            heroAnimator.SetBool("isJumping", true);
        }
    }

    private void HorizontalMovement(float direction)
    {
        playerRigidbody2D.velocity = new Vector2(movementCurve.Evaluate(direction),playerRigidbody2D.velocity.y);
        if(direction>0 && !heroLooksRight)
        {
            TurnAround();
        }
        else if (direction<0 && heroLooksRight)
        {
            TurnAround();
        }
    }

    private void TurnAround()
    {
        heroLooksRight = !heroLooksRight;
        heroSpriteRenderer.flipX = !heroSpriteRenderer.flipX;
    }

    private void Teleportation()
    {
        gameObject.transform.position = teleportationPoint.position;
    }
}

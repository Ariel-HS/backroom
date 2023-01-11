using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput; 
    Vector2 jumpInput;
    Rigidbody2D myRigidbody;
    BoxCollider2D boxCollider;
    float horizontalMove = 0f;
    public Animator anim;
    private Vector3 mousePos;
    private Camera mainCam;
    Transform playerSprites;

    [SerializeField] AudioClip runSFX;
    [SerializeField] [Range(0f, 1f)] float runVolume = 1f;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpPower = 15f;
    [SerializeField] private LayerMask platformLayer;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerSprites = transform.Find("playerSprites");
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        FlipSprite();

        horizontalMove = moveInput.x * runSpeed;
        if(horizontalMove > 0)
        {
            PlayRunSFX();
        }
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if(isGrounded())
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpPower);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x*runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity; 
    }

    void FlipSprite()
    {
        Vector3 rotation = mousePos - transform.position;

        float angle = Mathf.Atan2(rotation.y, rotation.x);

        if(-1.5 < angle && angle < 1.5)
        {
            playerSprites.localScale = Vector3.one;
        }
        else if (angle > -1.5 && angle > 1.5)
        {
            playerSprites.localScale = new Vector3(-1,1,1);
        }
    }

    private bool isGrounded()/// cek apakah di bawah ada ground/platform
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, platformLayer);
        return raycastHit.collider != null;
    }

    void PlayRunSFX()
    {
        if(runSFX != null)
        {
            AudioSource.PlayClipAtPoint(runSFX, Camera.main.transform.position, runVolume);
        }
    }
}

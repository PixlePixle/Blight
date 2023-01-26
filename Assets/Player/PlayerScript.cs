using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Controls controls;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float dash = 1f;
    [SerializeField]
    private float dashTime = 3f;
    [SerializeField]
    private float dashCooldown = 0.2f;
    private float dashCooldownTimer = -1f;

    private float timer = 0f;
    bool dashing = false;
    private Rigidbody rb;

    private Vector2 move = Vector2.zero;
    Vector2 currentMovement = Vector2.zero;

    private void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Movement.Dash.performed += Dash;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Dash(InputAction.CallbackContext ctx)
    {
        if(!dashing && dashCooldownTimer < 0f) // If not currently dashing and cooldown is over
        {
            timer = dashTime;
            dashing = true;
            currentMovement = move;
        }
        
    }

    private void FixedUpdate()
    {
        if (!dashing) // If not dashing, do movement
        {
            rb.velocity = new Vector3(move.x * speed, 0f, move.y * speed);
        }
        else // Start a timer for dash
        {
            rb.velocity = Vector3.Normalize(new Vector3(Mathf.Abs(currentMovement.x) > 0f ? Mathf.Sign(currentMovement.x): 0f, 0f, Mathf.Abs(currentMovement.y) > 0f ? Mathf.Sign(currentMovement.y) : 0f)) * dash;
            timer -= Time.fixedDeltaTime; // Decreases the timer
            if(timer < 0f) // Once the timer hits 0, the dash is over and the dash goes on cooldown
            {
                dashing = false;
                dashCooldownTimer = dashCooldown;
            }
        }
        if (dashCooldownTimer > 0f) // Decreases the dash cooldown
            dashCooldownTimer -= Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the current pressed keys and stores it
        move = controls.Movement.WASD.ReadValue<Vector2>();

        //Some unworking mouse code
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10f;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(Worldpos);

    }
}

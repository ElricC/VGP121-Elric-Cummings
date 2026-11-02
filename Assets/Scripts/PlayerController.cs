
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    #region Tunable Parameters
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    #endregion

    #region Component References
    private Rigidbody2D rb;
    #endregion


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
        rb.freezeRotation = true;
    }


    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        bool jumpPressed = Input.GetButtonDown("Jump");

    
        rb.linearVelocityX = moveX * moveSpeed;


        if (jumpPressed && Mathf.Abs(rb.linearVelocityY) < 0.01f)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    bool isJumped = false;
    public float speedIncreasePerPoint = 0.1f;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = Vector3.zero;

        if (horizontalInput > 0 && rb.position.x < 4f)
            horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        else if (horizontalInput < 0 && rb.position.x > -4f)
            horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        if (Input.GetKeyDown(KeyCode.Space) && !isJumped)
        {
            Vector3 jump = transform.up * 3f;
            rb.MovePosition(rb.position + forwardMove + horizontalMove + jump);
            isJumped = true;
            Invoke(nameof(ResetJump), 0.8f);
        }
        else
            rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }

    void ResetJump()
    {
        isJumped = false;
    }

}
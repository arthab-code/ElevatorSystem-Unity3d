using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mSpeed = 500f;
    public float mMouseSensivity = 100f;
    public float mGravity = -9f;
    public float mJumpHeight = 0.3f;
    public Transform mGroundCheck;
    public LayerMask mLayerMask;

    private bool mIsGrounded;
    private Transform mBody;
    private Vector2 mRotation;
    private float mMouseX = 0f;
    private float mMouseY = 0f;
    private CharacterController mController;
    private Vector3 mPlayerVelocity;
   

    // Start is called before the first frame update
    void Start()
    {
        mBody = GetComponent<Transform>();
        mController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraLook();
        PlayerMovement();
        PlayerJump();
    }

    private void CameraLook()
    {
        float mouseXtemporary = Input.GetAxis("Mouse X") * mMouseSensivity * Time.deltaTime;
        float mouseYtemporary = Input.GetAxis("Mouse Y") * mMouseSensivity * Time.deltaTime;

        mMouseX -= mouseYtemporary;
        mMouseY += mouseXtemporary;

        mMouseX = Mathf.Clamp(mMouseX, -90f, 90f);

        mRotation = new Vector2(mMouseX, mMouseY);

        transform.localRotation = Quaternion.Euler(new Vector3(mRotation.x, mRotation.y, 0f));
    }

    private void PlayerMovement()
    {
        float positionY = Input.GetAxis("Vertical");
        float positionX = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * positionX + transform.forward * positionY;
        mController.Move(mSpeed * Time.deltaTime * move);
        

        mPlayerVelocity.y += mGravity * Time.deltaTime;
        mController.Move(mPlayerVelocity * Time.deltaTime * mSpeed);

        if (mIsGrounded && mPlayerVelocity.y < 0)
        {
            mPlayerVelocity.y = 0f;
        }

    }

    private void PlayerJump()
    {
        mIsGrounded = Physics.CheckSphere(mGroundCheck.position, 10f, mLayerMask);

        if (mIsGrounded && mPlayerVelocity.y < 0)
        {
            mPlayerVelocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && mIsGrounded)
        {

            mPlayerVelocity.y += Mathf.Sqrt(mJumpHeight * -2f * mGravity);
          
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public float walkSpeed = 5.0F;
    public float jumpHeight = 10.0F;
    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotateValue;
    private Quaternion rotation;
    private float mouseX;
    private float mouseY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = GetComponentInChildren<Camera>();
        handleCamera(transform, camera.transform);
        handleMovement();
    }

    private void handleCamera(Transform character, Transform camera)
    {
        mouseX = Input.GetAxis("Mouse X") * 2f;
        mouseY = Input.GetAxis("Mouse Y") * 2f;
        Debug.Log(mouseX + ":" + mouseY);
        character.localRotation *= Quaternion.Euler(0f, mouseY, 0f);
        camera.localRotation *= Quaternion.Euler(-mouseX, 0f, 0f);
        camera.localRotation = ClampRotationAroundXAxis(camera.localRotation);
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -90f, 90f);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }

    private void handleMovement()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

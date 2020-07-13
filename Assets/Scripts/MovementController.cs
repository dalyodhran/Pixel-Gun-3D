using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    private float lookSensativity = 3f;

    [SerializeField]
    GameObject fpsCamera;

    private Vector3 velocity = Vector3.zero;

    private Vector3 rotation = Vector3.zero;

    private float cameraUpAndDownRotation = 0f;

    private float currentCameraUpAndDownRotation = 0f;

    private Rigidbody rb;

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate movement velocity as a 3d vector
        float _xMovement = Input.GetAxis("Horizontal");
        float _zMovement = Input.GetAxis("Vertical");

        Vector3 _movementHorizontal = transform.right * _xMovement;
        Vector3 _movementVertical = transform.forward * _zMovement;

        //Final movement velocity
        Vector3 _movementVelocity = (_movementHorizontal + _movementVertical).normalized * speed;


        //Apply movement
        Move(_movementVelocity);

        //Calculate rotation as a 3D vector for turing around
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _rotationVector = new Vector3(0, _yRotation, 0) * lookSensativity;

        //Apply rotation
        Rotate(_rotationVector);

        //Calculate loop up and down camera rotation
        float cameraUpDownRotation = Input.GetAxis("Mouse Y") * lookSensativity;

        //Apply
        RotateCamera(cameraUpDownRotation);
    }

    #endregion

    #region Private methods

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (fpsCamera != null)
        {
            currentCameraUpAndDownRotation -= cameraUpAndDownRotation;
            currentCameraUpAndDownRotation = Mathf.Clamp(currentCameraUpAndDownRotation, -85, 85);
            fpsCamera.transform.localEulerAngles = new Vector3(currentCameraUpAndDownRotation, 0, 0);
        }
    }

    private void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    private void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }

    private void RotateCamera(float cameraUpAndDownRotation)
    {
        this.cameraUpAndDownRotation = cameraUpAndDownRotation;
    }

    #endregion
}

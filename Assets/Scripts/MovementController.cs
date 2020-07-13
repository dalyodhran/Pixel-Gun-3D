using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    private Vector3 velocity = Vector3.zero;

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
    }

    #endregion

    #region Private methods

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    #endregion
}

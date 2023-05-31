using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public PlayerDirection playerDirection;

    private Formulas m_formulas;

    // Start is called before the first frame update
    private void Start()
    {
        m_formulas = new Formulas();
    }

    // Update is called once per frame
    private void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        float yMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;
        Vector3 movementVector = new Vector3(xMovement, yMovement, 0);
        transform.position = m_formulas.Move(transform.position, movementVector);
        updatePlayerDirection(xMovement, yMovement);
    }

    private void updatePlayerDirection(float t_xMovement, float t_yMovement)
    {
        switch (t_xMovement) {
            case < 0:
                playerDirection = PlayerDirection.West;
                break;
            case > 0:
                playerDirection = PlayerDirection.East;
                break;
        }
        switch (t_yMovement) {
            case < 0:
                playerDirection = PlayerDirection.South;
                break;
            case > 0:
                playerDirection = PlayerDirection.North;
                break;
        }
    }
}

public enum PlayerDirection { North, South, East, West}

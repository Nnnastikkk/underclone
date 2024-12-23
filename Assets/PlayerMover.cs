using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f; // скорость движения

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movementDirection = new Vector2(horizontal, vertical).normalized;

        transform.Translate(movementDirection * _moveSpeed * Time.deltaTime);
    }
}

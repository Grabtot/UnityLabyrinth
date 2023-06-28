using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] protected Transform _cameraTransform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _cameraRotationSpeed = 100;

    private int _coinsCount;
    [HideInInspector] public UnityEvent<int> LevelFinished;

    public void AddCoin()
    {
        _coinsCount++;
        Debug.Log($"Coin added. Coins count: {_coinsCount}");
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = GetCameraForward() * verticalInput + GetCameraRight() * horizontalInput;
        movement.Normalize();

        _characterController.SimpleMove(movement * _speed);

        if (Input.GetAxis("Mouse X") != 0)
        {
            float mouseX = Input.GetAxis("Mouse X") * _cameraRotationSpeed * Time.deltaTime;

            transform.Rotate(0f, mouseX, 0f);
        }
    }

    private Vector3 GetCameraForward()
    {
        Vector3 cameraForward = _cameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();
        return cameraForward;
    }

    private Vector3 GetCameraRight()
    {
        Vector3 cameraRight = _cameraTransform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();
        return cameraRight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelFinished.Invoke(_coinsCount);
        }
    }
}

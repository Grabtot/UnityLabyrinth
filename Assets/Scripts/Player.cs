using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    private Rigidbody _rigidbody;
    private int _coinsCount;

    public UnityEvent<int> LevelFinished;
    public void AddCoin()
    {
        _coinsCount++;
        Debug.Log($"Coin added. Coins count: {_coinsCount}");
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float mouseY = Input.GetAxis("Mouse X");

        float verticalSpeed = verticalInput * _speed;
        float horizontalSpeed = horizontalInput * _speed;

        _rigidbody.velocity = new Vector3(verticalSpeed, 0, horizontalSpeed);

        transform.Rotate(0, mouseY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelFinished.Invoke(_coinsCount);
        }
    }
}

using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;

    private void Update()
    {
        var rotation = transform.rotation.eulerAngles;
        rotation.y += _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().AddCoin();
        }
        gameObject.SetActive(false);
    }
}

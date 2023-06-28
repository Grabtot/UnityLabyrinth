using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _coinsCountText;

    private void Start()
    {
        _player.LevelFinished.AddListener(ShowFinishText);
    }

    private void ShowFinishText(int coinsCount)
    {
        _coinsCountText.text = $"{coinsCount} coins ";
    }
}

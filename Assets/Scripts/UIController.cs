using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _coinsCountText;
    [SerializeField] private Canvas _ui;

    private void Start()
    {
        _ui.gameObject.SetActive(false);
        _player.LevelFinished.AddListener(OnLevelFinished);
    }

    private void OnLevelFinished(int coinsCount)
    {
        _ui.gameObject.SetActive(true);
        _coinsCountText.SetText($"Coins: {coinsCount} ");
    }
}

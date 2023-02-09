using GB;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHpBarDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHp;
    [SerializeField] private TextMeshProUGUI _playerHealthLabel;

    void Start()
    {
        OnHpChanged(_playerHp.Health, _playerHp.MaxHealth);
    }
    //private void Update()            // 2ой вариант
    //{
    //    OnHpChanged(_playerHp.Health, _playerHp.MaxHealth);
    //}
    private void Subscribe(PlayerHealth _playerHp)
    {
        _playerHp.AddHpListener(OnHpChanged);
        OnHpChanged(_playerHp.Health, _playerHp.MaxHealth);
    }
    private void Unsubscribe(PlayerHealth _playerHp)
    {
        _playerHp.RemoveHpListener(OnHpChanged);
    }
    public void OnHpChanged(float currentHp, float maxHp)
    {
        _playerHealthLabel.text = $"Health: {currentHp} / {maxHp}";
    }
}

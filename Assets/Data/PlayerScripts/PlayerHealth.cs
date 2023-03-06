using GB;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GB
{
    public sealed class PlayerHealth : BaseHealth, ITakeDamage, ILog
    {
        [SerializeField] private int _hp = 4;
        [SerializeField] private int _MaxHp = 5;

        [SerializeField] private AudioSource TakeDamageSFX;
        [SerializeField] private AudioSource HealSFX;
        [SerializeField] private GameObject _Lose;
        [SerializeField] private TextMeshProUGUI _playerHealthLabel;

        private UIHpBarDisplay _uIHp;
        private HpBarDisplay _hpBarMatColor;

        [Space(5)] [SerializeField] private UnityEvent _eventOnDie;
        private Action<float, float> OnHpChanged;

        public void Start()
        {
            (int currentHP, int maxHP) playerHp = GetHP();
            playerHp.currentHP = _hp;
            playerHp.maxHP = _MaxHp;

            _uIHp = GetComponentInChildren<UIHpBarDisplay>();
            _uIHp.OnHpChanged(playerHp.currentHP, playerHp.maxHP);
            _playerHealthLabel.text = "Health: " + playerHp.currentHP.ToString();
            _hpBarMatColor = GetComponentInChildren<HpBarDisplay>();
            _hpBarMatColor.OnMaterialColorChanged(playerHp.currentHP, playerHp.maxHP);
        }

        public void TakeDamage(int damageValue)
        {
            this.Health -= damageValue;
            TakeDamageSFX.Play();

            OnHpChanged?.Invoke(this.Health, this.MaxHealth);
            _uIHp.OnHpChanged(Health, MaxHealth);             // 1й вариант
            _hpBarMatColor.OnMaterialColorChanged(Health, MaxHealth);
            _playerHealthLabel.text = "Health: " + Health.ToString();
            Debug.Log($" {name} - <color=red>Damaged</color>");
            if (Health <= 0)
            {
                Health = 0;
                _hpBarMatColor.OnMaterialColorChanged(Health, MaxHealth);
                _playerHealthLabel.text = "Health: " + Health.ToString();
                Die();
                Log<string>($"{ name }", " - Die");
            }
        }
        public override void Heal(int healthValue)
        {
            (int currentHP, int maxHP) playerHpHW11 = GetHP();

            if (Health < playerHpHW11.maxHP) //   if (_hp < _MaxHp)
            {
                this.Health += healthValue; //  Health += healthValue;
            }
            if (Health > MaxHealth)
            {
                Health = playerHpHW11.maxHP;
            }
            if (Health >= 0)
            {
                _Lose.SetActive(false);
            }
            _playerHealthLabel.text = "Health: " + playerHpHW11.currentHP.ToString();
            _uIHp.OnHpChanged(playerHpHW11.currentHP, playerHpHW11.maxHP);
            _hpBarMatColor.OnMaterialColorChanged(playerHpHW11.currentHP, playerHpHW11.maxHP);
            HealSFX.Play();
            Log<string>($"{name}", " - PlayerHealth.Heal. override void Heal");
            #region HW 11 test
            // base.Heal(healthValue);
            //if (playerHpHW11.currentHP < playerHpHW11.maxHP)
            //{
            //    playerHpHW11.currentHP += healthValue;
            //}
            //if (playerHpHW11.currentHP > playerHpHW11.maxHP)
            //{
            //    playerHpHW11.currentHP = playerHpHW11.maxHP;
            //}
            //if (playerHpHW11.currentHP >= 0)
            //{
            //    _Lose.SetActive(false);
            //}
            //_playerHealthLabel.text = "Health: " + Health.ToString();
            //_uIHp.OnHpChanged(Health, MaxHealth);
            //_hpBarMatColor.OnMaterialColorChanged(Health, MaxHealth);
            //HealSFX.Play();
            //Log<string>($"{name}", " - PlayerHealth.Heal. override void Heal");
            // Debug.Log($" {name} - Heal");
            #endregion
        }
        public override void Die()
        {
            Debug.Log($" {name} - PlayerHealth. Die.");
            if (Health <= 0)
            {
                _Lose.SetActive(true);
            }
            _eventOnDie.Invoke();
        }

        public void AddHpListener(Action<float, float> onHpChanged)
        {
            OnHpChanged += onHpChanged;
        }
        public void RemoveHpListener(Action<float, float> onHpChanged)
        {
            OnHpChanged -= onHpChanged;
        }

        public void Log<String>(string name, string msg)
        {
            Debug.Log($" { name } - { msg }");
        }
    }

}

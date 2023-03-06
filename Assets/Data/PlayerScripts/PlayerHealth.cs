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
            Health = _hp; MaxHealth = _MaxHp;
            (int currentHP, int maxHP) playerHp = GetHP();
            // Debug.Log("PlayerHealth-Start-base- " + Health + ", " + MaxHealth);
            // Debug.Log("PlayerHealth-Start-playerHpHW11- " + playerHp);
            //playerHp.currentHP = _hp;
            //playerHp.maxHP = _MaxHp;
            _uIHp = GetComponentInChildren<UIHpBarDisplay>();
            _uIHp.OnHpChanged(Health, MaxHealth);
            _playerHealthLabel.text = "Health: " + Health.ToString();
            _hpBarMatColor = GetComponentInChildren<HpBarDisplay>();
            _hpBarMatColor.OnMaterialColorChanged(Health, MaxHealth);
        }
        public override (int currentHP, int maxHP) GetHP()
        {
           // Debug.Log("PlayerHealth-GetHP " + Health + ", " + MaxHealth);
            return (this.Health, MaxHealth);
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
            // (int currentHP, int maxHP) playerHpHW11 = GetHP();
           // Debug.Log("PlayerHealth-override.Heal-base " + Health + ", " + MaxHealth);
            // Debug.Log("PlayerHealth-override.Heal-playerHpHW11- " + playerHpHW11);

            if (Health < _MaxHp)
            {
                this.Health += healthValue;
            }
            else
            {
                Debug.LogWarning(" _playerHealth.Heal is max");
            }
            if (Health > _MaxHp)
            {
                Health = _MaxHp;
            }
            if (Health >= 0)
            {
                _Lose.SetActive(false);
            }
            _uIHp.OnHpChanged(Health, MaxHealth);
            _hpBarMatColor.OnMaterialColorChanged(Health, MaxHealth);
            _playerHealthLabel.text = "Health: " + Health.ToString();
            HealSFX.Play();
            // Log<string>($"{name}", " - PlayerHealth.Heal. override void Heal");
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

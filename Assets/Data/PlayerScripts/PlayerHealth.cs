using GB;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GB
{
    public sealed class PlayerHealth : BaseHealth, ITakeDamage, ILog  //MonoBehaviour
    {
        [SerializeField] private int _hp = 4;

        [field: SerializeField] private int _MaxHp = 5;
        [SerializeField] private AudioSource TakeDamageSFX;
        [SerializeField] private AudioSource HealSFX;
        [SerializeField] private GameObject _Lose;
        [SerializeField] private TextMeshProUGUI _playerHealthLabel;
      //  [SerializeField] 
        private UIHpBarDisplay _uIHp;
      //  [SerializeField] 
        private HpBarDisplay _hpBarMatColor;

        [Space(5)] [SerializeField] private UnityEvent _eventOnDie;

        private Action<float, float> OnHpChanged;
        public void Start()
        {
            this.Health = _hp;
            this.MaxHealth = _MaxHp;
            _uIHp = GetComponentInChildren<UIHpBarDisplay>();   // 1й вариант
            _uIHp.OnHpChanged(Health, MaxHealth);                 // 1й вариант
            _playerHealthLabel.text = "Health: " + Health.ToString();
            _hpBarMatColor = GetComponentInChildren<HpBarDisplay>();
            _hpBarMatColor.OnMaterialColorChanged(Health, MaxHealth);
        }

        //public PlayerHealth()
        //{
        //    Health = 4;
        //    _playerHealthLabel.text = "Health: " + Health.ToString();
        //}
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
            base.Heal(healthValue);
            if (Health >= 0)
            {
                _Lose.SetActive(false);
            }
            _playerHealthLabel.text = "Health: " + Health.ToString();
            _uIHp.OnHpChanged(Health, MaxHealth);
            _hpBarMatColor.OnMaterialColorChanged(Health, MaxHealth);
            HealSFX.Play();
            Log<string>($"{name}", " - PlayerHealth.Heal");
            // Debug.Log($" {name} - Heal");
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

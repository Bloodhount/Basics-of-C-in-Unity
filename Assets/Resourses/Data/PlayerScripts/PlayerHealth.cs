using GB;
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
        [field: SerializeField] private  int _MaxHp = 5;
        [SerializeField] private AudioSource TakeDamageSFX;
        [SerializeField] private AudioSource HealSFX;
        [SerializeField] private GameObject _Lose;
        [SerializeField] private TextMeshProUGUI _playerHealthLabel;

        [Space(5)] [SerializeField] private UnityEvent _eventOnDie;
        public void Start()
        {
            Health = _hp;
            MaxHealth = _MaxHp;

            _playerHealthLabel.text = "Health: " + Health.ToString();
        }

        //public PlayerHealth()
        //{
        //    Health = 4;
        //    _playerHealthLabel.text = "Health: " + Health.ToString();
        //}
        public void TakeDamage(int damageValue)
        {
            Health -= damageValue;
            TakeDamageSFX.Play();
            _playerHealthLabel.text = "Health: " + Health.ToString();
            Debug.Log($" {name} - <color=red>Damaged</color>");
            if (Health <= 0)
            {
                Health = 0; _playerHealthLabel.text = "Health: " + Health.ToString();
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
        public void Log<String>(string name, string msg)
        {
            Debug.Log($" { name } - { msg }");
        }
    }

}

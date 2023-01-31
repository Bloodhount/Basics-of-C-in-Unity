using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

namespace GB
{
    public class EnemyHealth : BaseHealth, ITakeDamage   //MonoBehaviour
    {
        public void TakeDamage(int damageValue)
        {
            Health -= damageValue;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            //Debug.Log($" {name} - Heal");
        }
    }
}

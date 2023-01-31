using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Debug;

namespace GB
{
    public class EnemyHealth : BaseHealth, ITakeDamage  //MonoBehaviour
    {

        public void TakeDamage(int damageValue)
        {
            Health -= damageValue; Log($" {name} - Damaged");
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace GB
{
    public static class PlayerAbilities // : MonoBehaviour // MonoBehaviour только для метода Awake()
    {
        public static TestDelegate TestDelegate_3;
        //________________________________________
        //private void Awake()
        //{
        //    TestDelegate_3 = SpeedBoost_2;
        //}
        //________________________________________
        public static void SpeedBoost(int value) //  TODO
        {
           // PlayerMoveComtroller.PlayerSpeedUp(1 * value);
            LogWarning("SpeedBoost. TestDelegate" + value);
        }
        public static void SpeedBoost_2()
        {
            LogWarning("SpeedBoost_2. TestDelegate");
        }
        public static void Heal()
        {
            LogWarning("Heal. TestDelegate");
        }
        public static void FreezeEnemy()
        {
            LogWarning("FreezeEnemy. TestDelegate");
        }
        //public static void StopAbility() // <T>(T type)
        //{
        //    PlayerMoveComtroller.PlayerChangeSpeed(-1);
        //    LogWarning("StopAbility.");
        //}
    }
}

using GB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDisplay : MonoBehaviour
{
    [SerializeField] private float hpToPlayEffect = 2f;
    [SerializeField] private PlayerHealth _playerHp;
    [SerializeField] private ParticleSystem _someEffect;

    void Start()
    {
        Subscribe();
    }

    public void Subscribe()
    {
        _playerHp.AddHpListener(OnHpChanged);
    }

    void OnHpChanged(float currentHp, float maxHp)
    {
        if (currentHp / maxHp < hpToPlayEffect)
        {
            _someEffect.Play();
        }
        else
        {
            _someEffect.Stop();
        }
    }
}

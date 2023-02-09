using GB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHp;
    // [SerializeField] 
    private Material materialRender;

    void Start()
    {
        Subscribe();
        var material_1 = Resources.Load<Material>("Materials/Gold");
        // var material_1 = Resources.Load<Material>("Materials/Grid_Glass");
        // var render = GetComponent<Renderer>();
        // render.material = material_1;

        materialRender = GetComponent<Renderer>().material;
        materialRender.color = Color.green;
    }

    public void Subscribe()
    {
        _playerHp.AddHpListener(OnMaterialColorChanged);
    }

    public void OnMaterialColorChanged(float currentHp, float maxHp)
    {
        if (currentHp / maxHp <= 0)
        {
            materialRender.color = Color.black;
        }
        else if (currentHp / maxHp <= 0.2)
        {
            materialRender.color = Color.red;
        }
        else if (currentHp / maxHp <= 0.4)
        {
            materialRender.color = Color.yellow;
        }
        else if (currentHp / maxHp <= 0.6)
        {
            materialRender.color = Color.green;
        }
        else
        {
            materialRender.color = Color.gray;
        }
    }
    private void OnMaterialColorChanged(float r, float g, float b, float a)
    {
        Vector4 vector = new Vector4(r, g, b, a);
        materialRender.color = vector;
    }
}

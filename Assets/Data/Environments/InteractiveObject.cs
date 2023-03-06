using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour, IFlay, IFlicker, IInteractable
{

    private Material _material;
    private float _lengthFlay;

    public bool IsInteractable { get; }
    //private DisplayBonuses _displayBonuses;

    //public void Interaction()
    //{
    //    _displayBonuses.Display(5);
    //    // Add bonus
    //}

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _lengthFlay = Random.Range(0.5f, 1.5f);
        // _displayBonuses = new DisplayBonuses();
    }
    private void Start()
    {
        ((IAction)this).Action();
        ((IInitialization)this).Action();
    }
    public void Action()
    {
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
    void IInitialization.Action()
    {
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = Color.red;
        }
    }
    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
    }
    public void Flicker()
    {
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
    }
    //protected override void Interaction()
    //{
    //    // Add bonus
    //}
}

//public sealed class DisplayBonuses
//{
//    private Text _text;
//    public DisplayBonuses()
//    {
//        _text = Object.FindObjectOfType<Text>();
//    }
//    public void Display(int value)
//    {
//        _text.text = $"Вы набрали {value}";
//    }
//}
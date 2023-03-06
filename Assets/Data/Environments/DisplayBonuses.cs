using UnityEngine;
using TMPro;

public sealed class DisplayBonuses : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _bonusCount = 0;
    //public DisplayBonuses()
    //{
    //     _text.text = GameObject.Find("test_text (1)").gameObject.transform.ToString();
    //    // _text = Object.FindObjectOfType<TextMeshProUGUI>();
    //}

    private void Start()
    {
        _text = GameObject.Find("test_text (1)").GetComponent<TextMeshProUGUI>();
        TextUpdate();
        // _text.text = GameObject.Find("test_text (1)").gameObject.transform.ToString();
    }
    public void Display(int value)
    {
        _bonusCount += value;
        TextUpdate();
    }
    private void TextUpdate()
    {
        _text.text = $"Scores {_bonusCount}.Pts";
    }
}

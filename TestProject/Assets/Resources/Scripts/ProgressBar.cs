using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private int _progress = 0;
    [SerializeField] private Image _bar;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake() { 
        _bar = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Start()
    {
        UpdateBarSize();
        UpdateText();
    }

    private void UpdateBarSize()
    {
        _bar.fillAmount = _progress/100;
    }
    private void UpdateText()
    {
        _text.text = _progress.ToString() + '%';
    }

    public void SetProgress(float progress)
    {
        _progress = (int)(progress * 100);
        UpdateBarSize();
        UpdateText();
    }
}

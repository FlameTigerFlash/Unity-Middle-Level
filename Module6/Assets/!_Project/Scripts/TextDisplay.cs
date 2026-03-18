using TMPro;
using UnityEngine;
using Zenject;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;

    private ISettingsLoader _settingsLoader;

    [Inject]
    public void Init(ISettingsLoader settingsLoader)
    {
        _settingsLoader = settingsLoader;
    }

    private void Start()
    {
        _settingsLoader.Setup();
        _textField.color = _settingsLoader.ScreenColor;
        _textField.text = _settingsLoader.ScreenText;
    }
}

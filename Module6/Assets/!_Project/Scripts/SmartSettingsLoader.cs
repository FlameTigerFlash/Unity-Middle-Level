using UnityEngine;

public class SmartSettingsLoader : ISettingsLoader
{
    public string ScreenText { get; set; }
    public Color ScreenColor { get; set; }

    public void Setup()
    {
        ScriptableSettings mySettings = Resources.Load<ScriptableSettings>("DefaultSettings");
        ScreenText = mySettings.ScreenText;
        ScreenColor = mySettings.ScreenColor;
    }
}

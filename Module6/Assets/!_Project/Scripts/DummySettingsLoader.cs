using UnityEngine;

public class DummySettingsLoader : ISettingsLoader
{
    public string ScreenText { get; set; }
    public Color ScreenColor { get; set; }

    public void Setup()
    {
        ScreenText = "Using Dummy!";
        ScreenColor = Color.red;
    }
}

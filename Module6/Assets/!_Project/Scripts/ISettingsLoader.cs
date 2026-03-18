using UnityEngine;

public interface ISettingsLoader
{
    public string ScreenText { get; set;}
    public Color ScreenColor { get; set;}

    public void Setup();
}

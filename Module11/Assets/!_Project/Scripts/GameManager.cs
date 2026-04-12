using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public LevelSettings LevelSettings;

    private void Start()
    {
        Debug.Log($"Level name: {LevelSettings.LevelName}");
        Debug.Log($"Waves count: {LevelSettings.WavesCount}");
        if (LevelSettings.IsUnique)
        {
            Debug.Log($"Unique Level!");
        }
        else
        {
            Debug.Log($"Ordinary level.");
        }
    }
}

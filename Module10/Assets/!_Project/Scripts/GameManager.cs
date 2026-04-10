using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _size = 100000;

    private string _filePath => Path.Combine(Application.persistentDataPath, "arrayData.xml");

    private float[] _data;

    private void Start()
    {
        _data = new float[_size];
        Setup();
    }

    private void OnSetupComplete()
    {
        Debug.Log("Setup Complete");
        for (int i = 0; i < Mathf.Min(10, _size); i++)
        {
            Debug.Log($"Element {i+1} = {_data[i]}");
        }
    }

    private async void Setup()
    {
        List<int> arr = ReadArray();
        await Task.Run(() => FillArray(arr));
        OnSetupComplete();
    }

    private void FillArray(List<int> arr)
    {
        for (int i = 0; i < _size; i++)
        {
            _data[i] = arr[(i % arr.Count)];
        }
    }

    private List<int> ReadArray()
    {
        if (!File.Exists(_filePath))
        {
            CreateDefaultFile();
        }

        XDocument doc = XDocument.Load(_filePath);
        XElement root = doc.Root;

        List<int> values = new List<int>();

        foreach (XElement element in root.Elements("Element"))
        {
            values.Add(int.Parse(element.Value));
        }
        return values;
    }

    private void CreateDefaultFile()
    {
        int[] defaultValues = { 1, -2, 3, 6, 25};
        XDocument doc = new XDocument(
            new XElement("Array",
                defaultValues.Select(v => new XElement("Element", v))
            )
        );
        doc.Save(_filePath);
    }
}

using System.Collections;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    [SerializeField] private float _lifetime = 2f;

    private void Start()
    {
        StartCoroutine(WaitForDestruction(_lifetime));
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    private IEnumerator WaitForDestruction(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Delete();
    }
}

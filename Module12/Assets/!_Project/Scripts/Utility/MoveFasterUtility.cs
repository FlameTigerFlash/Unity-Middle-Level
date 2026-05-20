using UnityEngine;

public class MoveFasterUtility : BaseUtility
{
    [SerializeField] private float _speedIncrement = 2f;
    public override void Execute(GameObject target)
    {
        ObjectMovement movement = target.GetComponent<ObjectMovement>();

        if (movement != null)
        {
            movement.SetSpeed(movement.Speed + _speedIncrement);
        }
        Destroy(gameObject);
    }
}

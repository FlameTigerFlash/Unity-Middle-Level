using System;
using UnityEngine;

public class TurnRedPerk : BasePerk
{
    public override void Execute(GameObject target)
    {
        Renderer renderer = target.GetComponentInChildren<Renderer>();

        if (renderer == null)
        {
            return;
        }

        if (!IsActive)
        {
            renderer.material.color = Color.red;
            IsActive = true;
        }
        else
        {
            renderer.material.color = Color.blue;
            IsActive = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShot : Interactible
{
    public int healthBonus;
    public GameObject healthBoost;

    public override void Interact(PlayerScript player) {
        base.Interact(player);
        player.Heal(healthBonus);
        healthBoost.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
    }
}

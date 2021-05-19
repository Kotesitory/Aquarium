using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Interactible
{
    public int scoreBonus;
    public GameObject loot;

    public override void Interact(PlayerScript player) {
        base.Interact(player);
        player.AddScore(scoreBonus);
        loot.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
    }
}

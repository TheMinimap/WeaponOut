﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WeaponOut.Items.Accessories
{
    public class StainedTooth : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableFists; }

        public override void SetStaticDefaults() // Brain of Cthulu
        {
            DisplayName.SetDefault("Stained Tooth");
            Tooltip.SetDefault(
                "Melee strikes on full health enemies has a chance to spawn a heart");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = 1;
            item.accessory = true;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PlayerFX>().heartDropper = true;
        }
    }
}

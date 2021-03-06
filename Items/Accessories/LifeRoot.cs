﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WeaponOut.Items.Accessories
{
    public class LifeRoot : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableFists; }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Symbiotic Root");
            Tooltip.SetDefault(
                "Hearts drop more frequently and heal 5 more life");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = 7;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PlayerFX>().heartDropper = true;
            player.GetModPlayer<PlayerFX>().heartBuff = true;
        }
    }
}

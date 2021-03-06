﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WeaponOut.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class GolemHeart : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableFists; }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Spark");
            Tooltip.SetDefault(
                "Reduces combo power cost by 2\n" +
                "Reduces combo power cost by 4 when below 50% life to heal");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = 8;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ModPlayerFists.Get(player).comboCounterMaxBonus -= 2;
            if(player.statLife < player.statLifeMax2 / 2)
            {
                ModPlayerFists.Get(player).comboCounterMaxBonus -= 4;
            }
        }
    }
}

﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace WeaponOut.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class ChampionLaurels : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableFists; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Champion Laurels");
            Tooltip.SetDefault("5% increased melee damage");
        }
        public override void SetDefaults()
        {
            item.defense = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = 7;

            item.width = 18;
            item.height = 18;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlanteraMask);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.05f;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
        }

        private byte armourSet = 0;
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            armourSet = 0;if (body.type == mod.ItemType<HighPowerBody>() &&
                legs.type == mod.ItemType<HighPowerLegs>())
            {
                armourSet = 1;
                return true;
            }
            else if (body.type == mod.ItemType<HighDefBody>() &&
                legs.type == mod.ItemType<HighDefLegs>())
            {
                armourSet = 2;
                return true;
            }
            else if (body.type == mod.ItemType<HighSpeedBody>() &&
                legs.type == mod.ItemType<HighSpeedLegs>())
            {
                armourSet = 3;
                return true;
            }
            return false;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            ModPlayerFists mpf = ModPlayerFists.Get(player);
            switch (armourSet)
            {
                case 1:
                    player.setBonus = "20 defense per 100 missing life (NOT DONE)";
                    //player.GetModPlayer<PlayerFX>().beserkDefence = true;
                    break;
                case 2:
                    player.setBonus = "Damage taken is reduced by 10%, temporarily reduces damage taken when not attacking";
                    player.endurance += 0.1f;
                    player.GetModPlayer<PlayerFX>().yomiEndurance += 0.6f;
                    break;
                case 3:
                    player.setBonus = "Maximum life acts as a second wind, heal maximum life with combos (NOT DONE)";
                    //player.GetModPlayer<PlayerFX>().secondWind = true;
                    break;
            }
        }
    }
}
﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace WeaponOut.Items.Accessories
{
    public class ChaosHook : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableAccessories; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hook of Chaos");
            Tooltip.SetDefault(
                Language.GetTextValue("ItemTooltip.RodofDiscord") +
                "\nCan teleport whilst suffering from Chaos State\n" + 
                "'Faster! Faster!'");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.IlluminantHook);
            item.shootSpeed += 0.5f;
            item.rare = 7;
            item.value += Item.sellPrice(0, 5, 0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<DiscordHook>(), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //Conversion from
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 1);
            recipe.SetResult(mod.ItemType<DiscordHook>());
            recipe.AddRecipe();
        }
    }
}

﻿using Terraria.ID;
using Terraria.ModLoader;

namespace WeaponOut.Items
{
    /// <summary>
    /// The only way to obtain mirror badge pre-hardmode, by fishing as a bonus.
    /// </summary>
    public class RustedBadge : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableAccessories; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Badge");
            Tooltip.SetDefault("'It could do with some polishing...'");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 20;
            item.rare = -1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<RustedBadge>(), 1);
            recipe.AddIngredient(ItemID.HardenedSand, 10); // Rough polish
            recipe.AddIngredient(ItemID.SandBlock, 5); // Fine polish
            recipe.AddIngredient(ItemID.Silk, 1); // Buffing
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(mod.ItemType<Accessories.MirrorBadge>(), 1);
            recipe.AddRecipe();
        }
    }
}

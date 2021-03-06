﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WeaponOut.Items.Weapons.Basic
{
    public class StaffOfExplosion : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableBasicContent; }

        public const int baseDamage = 40;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Explosion");
            Tooltip.SetDefault(
                "Create a powerful explosion at a location\n" +
                "Increase channel speed by standing still\n" +
                "Enemies are more likely to target you while casting");
        }
        public override void SetDefaults()
        {
            item.width = 52;
            item.height = 14;
            item.scale = 1f;

            item.magic = true;
            item.channel = true;
            item.mana = 10;
            item.damage = baseDamage; //damage * (charge ^ 2) *1(0) - *25(8) - *160(11) - *1000(15)
            item.knockBack = 3f; //up to x2.18
            item.autoReuse = true;

            item.noMelee = true;
            Item.staff[item.type] = true; //rotate weapon, as it is a staff
            item.shoot = mod.ProjectileType<Projectiles.Explosion>();
            item.shootSpeed = 1;

            item.useStyle = 5;
            item.UseSound = SoundID.Item8;
            item.useTime = 60;
            item.useAnimation = 60;

            item.rare = 8;
            item.value = Item.sellPrice(0, 10, 0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WandofSparking, 1); // Surface chest
            recipe.AddIngredient(ItemID.RubyStaff, 1); // Extractinator, or Gold ore world
            recipe.AddIngredient(ItemID.MeteorStaff, 1); // Meteorite
            recipe.AddIngredient(ItemID.InfernoFork, 1); // Inferno caster
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UseStyle(Player player)
        {
            PlayerFX.modifyPlayerItemLocation(player, -4, -5);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            return true;
        }
    }
}
﻿using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WeaponOut.Items
{
    public class SparkleStar : ModItem
    {
        public override bool Autoload(ref string name) { return ModConf.enableAccessories; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lucky Shard");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.healLife = 3;
            item.healMana = 3;
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            if (Main.rand.Next(20) == 0)
            {
                Dust d = Dust.NewDustDirect(item.position, item.width, item.headSlot, 57 + Main.rand.Next(2), 0f, 0f, 200);
                d.noGravity = true;
                d.velocity *= 2f;
            }

            gravity /= 2f; // 0.1f
            maxFallSpeed *= 1.5f;

            // Bouncy
            if (item.velocity.Y == 0)
            {
                Main.PlaySound(2, (int)item.position.X, (int)item.position.Y, 25, 0.1f, 0.4f); // sparkly bounce effect
                for (int i = 0; i < 4; i++)
                {
                    Dust d = Dust.NewDustDirect(item.position, item.width, item.headSlot, 57 + Main.rand.Next(2), 0f, 0f, 200);
                    d.noGravity = true;
                    d.velocity.X *= 2f;
                }
                item.velocity.Y = -2f;
            }
        }
        public override bool CanPickup(Player player) { return true; }
        public override bool OnPickup(Player player)
        {
            player.statLife += item.healLife;
            player.statMana += item.healMana;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(item.healLife, true);
                player.ManaEffect(item.healMana);
            }

            Main.PlaySound(2, -1, -1, 4, 0.3f, 0.2f); // mini heal effect
            return false;
        }

        public override void GrabRange(Player player, ref int grabRange)
        {
            grabRange = Player.defaultItemGrabRange * 2;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = Main.itemTexture[item.type];
            
            spriteBatch.Draw(texture,
                item.Center - Main.screenPosition,
                Main.itemAnimations[item.type].GetFrame(texture),
                new Color(1f, 1f, 1f, 0.5f),
                rotation, item.Center - item.position,
                Main.cursorScale,
                SpriteEffects.None, 0f);
            return false;
        }
    }
}

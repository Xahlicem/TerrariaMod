using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class ChannelT : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Channeler's Trident");
            Tooltip.SetDefault("A unique trident which spins around when thrust.");
        }

        public override void SetDefaults() {
            item.damage = 25;
            item.useStyle = 5;
            item.useAnimation = 30;
            item.useTime = 35;
            item.shootSpeed = 3.4f;
            item.knockBack = 4f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ChannelTProj");
            item.value = 1000;
            item.noMelee = true; // Important because the spear is acutally a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.melee = true;
            item.autoReuse = true; // Most spears dont autoReuse, but it's possible
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(20, 0);
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[item.shoot] < 1; // This is to ensure the spear doesn't bug out when using autoReuse = true
        }
        public class ChannelTGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(20) == 0) {
                    if (npc.type == mod.NPCType("Channeler")) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("ChannelT"), 1);
                    }
                }
            }
        }
    }
}
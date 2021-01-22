using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    public class D20 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("20-Sided Dice");
            Tooltip.SetDefault("Better pray to RNGeesus, you and me both. 10x Multiplier.");
        }

        public override void SetDefaults() {
            item.damage = 20;
            item.thrown = true;
            item.lavaWet = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item11;
            item.consumable = true;
            item.autoReuse = true;
            item.maxStack = 10;
            item.shoot = ModContent.ProjectileType<Projectiles.D20Proj>();
            item.shootSpeed = 20f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int d = Main.rand.Next(20) + 1;
            damage = (int)(d * 10);
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public class D20GlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(8) == 0) {
                    if (npc.type == NPCID.MoonLordCore) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Throwing.D20>(), 1);
                    }
                }
            }
        }
    }
}
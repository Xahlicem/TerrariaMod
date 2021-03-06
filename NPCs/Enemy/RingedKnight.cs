using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class RingedKnight : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ringed Knight");
            Main.npcFrameCount[npc.type] = 17;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.SolarSolenian);
            npc.scale = 1;
            npc.width = 40;
            npc.height = 40;
            //npc.aiStyle = 39;
            aiType = NPCID.SolarSolenian;
            animationType = NPCID.SolarSolenian;
            npc.damage = 150;
            npc.defense = 400;
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000f;
            npc.knockBackResist = 0.02f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.RingedKnightBanner>();
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedAncientCultist) {
                return SpawnCondition.Underworld.Chance * 0.15f;
            } else return 0f;
        }
        public override void PostDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor) {
            DrakSolzUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Enemy/RingedKnight_GlowMask"), -4f);
        }

        /*public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackKnight_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackKnight_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackKnight_Gore_3"));
            Main.gore[g].scale = npc.scale;
            if (Main.rand.Next(15) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightHelmet>(), ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightArmor>(), ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightLeggings>()
                }));
            //if (Main.rand.Next(8) == 0) Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Melee.DragonSlayerSpear>());
            Item.NewItem(npc.Center, npc.width, npc.height, ModContent.ItemType<Items.Misc.Titanite>(), Main.rand.Next(1, 2));
        }*/
    }
}
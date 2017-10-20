using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class SilverKnightArcher : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight Archer");
            Main.npcFrameCount[npc.type] = 12;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.CultistArcherBlue);
            npc.scale = 1;
            npc.width = 40;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.CultistArcherBlue;
            animationType = NPCID.CultistArcherBlue;
            npc.damage = 120;
            npc.defense = 50;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 7500f;
            npc.knockBackResist = 0.05f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.SilverKnightBanner>();
        }

       /* public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedMechBossAny && Main.raining)
                return SpawnCondition.OverworldHallow.Chance * 0.08f;
            else return 0f;
        }*/
        public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_3"));
            Main.gore[g].scale = npc.scale;
            if (Main.rand.Next(20) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    mod.ItemType<Items.Armor.SilverKnight.SilverKnightHelmet>(), mod.ItemType<Items.Armor.SilverKnight.SilverKnightArmor>(), mod.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings>()
                }));
            //if (Main.rand.Next(8) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.DragonSlayerSpear>());
            Item.NewItem(npc.Center, npc.width, npc.height, mod.ItemType<Items.Ranged.DragonslayerGreatarrow>(), Main.rand.Next(1, 5));
        }
    }
}
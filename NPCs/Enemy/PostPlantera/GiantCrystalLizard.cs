using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PostPlantera {
    public class GiantCrystalLizard : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Giant Crystal Lizard");
            Main.npcFrameCount[npc.type] = 15;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.SolarSroller);
            npc.scale = 2.5f;
            npc.width = 24;
            npc.height = 38;
            npc.aiStyle = 39;
            //aiType = NPCID.SolarSroller;
            animationType = NPCID.SolarSroller;
            npc.damage = 120;
            npc.defense = 65;
            npc.lifeMax = 2500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 250f;
            npc.knockBackResist = 0f;
            npc.rarity = 1;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.GiantCrystalLizardBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedPlantBoss)
                return SpawnCondition.Cavern.Chance * 0.01f;
            else return 0f;
        }
        public override void NPCLoot() {
            for (int i = 0; i < 5; i++) {
                DrakSolz.CreateGore(mod, npc, "Gores/GiantCrystalLizard/GiantCrystalLizard_Gore_" + i);
                if (i == 4)
                    DrakSolz.CreateGore(mod, npc, "Gores/GiantCrystalLizard/GiantCrystalLizard_Gore_4");
            }

            DrakSolz.DropItem(npc, 100f, ModContent.ItemType<Items.Misc.Twink>(), Main.rand.Next(2, 4));
            if (NPC.downedAncientCultist)
                DrakSolz.DropItem(npc, 100f, ModContent.ItemType<Items.Misc.Titanite>(), Main.rand.Next(1, 3));
        }
    }
}
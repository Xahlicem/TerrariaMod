using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode.Hollow {

    public class Hollow_Armor_Shirtless : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hollow");
            Main.npcFrameCount[npc.type] = 15;
        }

        public override void SetDefaults() {
            npc.aiStyle = 3;
            aiType = NPCID.RustyArmoredBonesAxe;
            animationType = NPCID.RustyArmoredBonesAxe;

            NPC clone = new NPC();
            clone.CloneDefaults(NPCID.RustyArmoredBonesAxe);
            npc.width = clone.width;
            npc.height = clone.height;
            npc.HitSound = clone.HitSound;
            npc.DeathSound = clone.DeathSound;
            npc.knockBackResist = 0.5f;
            clone = null;

            npc.damage = 16;
            npc.defense = 8;
            npc.lifeMax = 60;
            npc.value = 90f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.HollowBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.OverworldNightMonster.Chance * 0.06f;
        }

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/Hollow/Gore_0");
            DrakSolz.CreateGore(mod, npc, "Gores/Hollow/Gore_1");
            DrakSolz.CreateGore(mod, npc, "Gores/Hollow/Gore_2");
            DrakSolz.CreateGore(mod, npc, "Gores/Hollow/Gore_3");
            if (Main.rand.Next(8) == 0) Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Misc.Lifegem>());
            if (Main.rand.Next(22) == 0) Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Misc.HomewardBone>());
            if (Main.rand.Next(22) == 0) Item.NewItem(npc.position, npc.width, npc.height, ItemID.SilverBroadsword, 1, false, 40);
        }
    }
}
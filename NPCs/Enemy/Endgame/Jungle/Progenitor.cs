using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Jungle {
    public class Progenitor : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Progenitor");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Crab);
            npc.scale = 0.8f;
            npc.width = 60;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.Crab;
            animationType = NPCID.Crab;
            npc.damage = 140;
            npc.defense = 2000;
            npc.lifeMax = 120000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.15f;
            npc.lavaImmune = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.LittleMushroomBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 2.4f, y);
            }
        }
    }
}
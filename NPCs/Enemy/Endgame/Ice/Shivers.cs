using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.NPCs.Enemy.Endgame.Ice {
    public class Shivers : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shivers");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.IceBat);
            npc.scale = 0.7f;
            npc.width = 30;
            npc.height = 30;
            //npc.aiStyle = 39;
            aiType = NPCID.CaveBat;
            animationType = NPCID.GiantBat;
            npc.damage = 150;
            npc.defense = 1500;
            npc.lifeMax = 60000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.05f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.LittleMushroomBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 2.0f, y);
            }
        }
    }
}
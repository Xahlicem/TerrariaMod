using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.NPCs.Enemy.Endgame.Ice {
    public class HearthSister : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hearth Sister");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.scale = 0.8f;
            npc.width = 48;
            npc.height = 60;
            npc.damage = 60;
            npc.defense = 1700;
            npc.lifeMax = 45000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0;
            npc.aiStyle = -1;
            npc.localAI[0] = 0f;
            npc.localAI[1] = 0f;
            npc.localAI[2] = 0f;
            npc.localAI[3] = 0f;
            npc.ai[3] = -1f;
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Spell_Time_Slot = 2;

        const int State_Spell = 1;

        public float AI_State {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public float AI_SpellTime {
            get { return npc.ai[AI_Spell_Time_Slot]; }
            set { npc.ai[AI_Spell_Time_Slot] = value; }
        }

        public override void AI() {
            npc.TargetClosest(true);
            AI_Timer++;
            if (AI_Timer == 115 ) {
                npc.TargetClosest(true);
                Vector2 speed = Main.player[npc.target].Center - npc.Center;
                DrakSolz.AdjustMagnitude(ref speed, 7.5f);
                int pro = Projectile.NewProjectile(npc.Center.X + (40 * npc.direction), npc.Center.Y - 25, speed.X * 1.4f, speed.Y * 1.4f, ProjectileID.IceSickle, npc.damage, 3f);
                Main.projectile[pro].friendly = false;
                Main.projectile[pro].hostile = true;
                Main.projectile[pro].tileCollide = false;
                Main.projectile[pro].velocity *= 2.2f;
                Main.projectile[pro].timeLeft = 90;

            }
            if (AI_Timer >= 150) {
                AI_Timer = 0;
            }
        }
        const int Frame_Spell = 0;
        const int Frame_Spell_2 = 1;
        const int Frame_Spell_3 = 2;
        const int Frame_Spell_4 = 3;
        const int Frame_Spell_5 = 4;
        const int Frame_Spell_6 = 5;
        const int Frame_Spell_7 = 6;
        const int Frame_Spell_8 = 7;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.frameCounter < 60) {
                npc.frame.Y = Frame_Spell * frameHeight;
            } else if (npc.frameCounter < 65) {
                npc.frame.Y = Frame_Spell_2 * frameHeight;
            } else if (npc.frameCounter < 70) {
                npc.frame.Y = Frame_Spell_3 * frameHeight;
            } else if (npc.frameCounter < 75) {
                npc.frame.Y = Frame_Spell_4 * frameHeight;
            } else if (npc.frameCounter < 80) {
                npc.frame.Y = Frame_Spell_5 * frameHeight;
            } else if (npc.frameCounter < 85) {
                npc.frame.Y = Frame_Spell_6 * frameHeight;
            } else if (npc.frameCounter < 90) {
                npc.frame.Y = Frame_Spell_7 * frameHeight;
            } else if (npc.frameCounter < 95) {
                npc.frame.Y = Frame_Spell_8 * frameHeight;
            } else if (npc.frameCounter < 100) {
                npc.frame.Y = Frame_Spell_5 * frameHeight;
            } else if (npc.frameCounter < 105) {
                npc.frame.Y = Frame_Spell_6 * frameHeight;
            } else if (npc.frameCounter < 110) {
                npc.frame.Y = Frame_Spell_7 * frameHeight;
            } else if (npc.frameCounter < 115) {
                npc.frame.Y = Frame_Spell_8 * frameHeight;
            } else if (npc.frameCounter < 120) {
                npc.frame.Y = Frame_Spell_5 * frameHeight;
            } else if (npc.frameCounter < 125) {
                npc.frame.Y = Frame_Spell_6 * frameHeight;
            } else if (npc.frameCounter < 130) {
                npc.frame.Y = Frame_Spell_7 * frameHeight;
            } else if (npc.frameCounter < 135) {
                npc.frame.Y = Frame_Spell_8 * frameHeight;
            } else if (npc.frameCounter < 140) {
                npc.frame.Y = Frame_Spell_4 * frameHeight;
            } else if (npc.frameCounter < 145) {
                npc.frame.Y = Frame_Spell_3 * frameHeight;
            } else if (npc.frameCounter < 150) {
                npc.frame.Y = Frame_Spell_2 * frameHeight;


            } else {
                npc.frameCounter = 0;
            }
        }
    }
}
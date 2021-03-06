using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PostPlantera {
    public class FlameWarmage : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Flame Warmage");
            Main.npcFrameCount[npc.type] = 7;
        }

        public override void SetDefaults() {
            npc.scale = 2f;
            npc.width = 30;
            npc.height = 52;
            npc.aiStyle = -1;
            npc.damage = 60;
            npc.defense = 35;
            npc.lifeMax = 1500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 225f;
            npc.knockBackResist = 0.0f;
            npc.teleporting = true;
            npc.teleportTime = 2f;
            npc.buffImmune[BuffID.Confused] = true;
            npc.localAI[0] = 0f;
            npc.localAI[1] = 0f;
            npc.localAI[2] = 0f;
            npc.localAI[3] = 0f;
            npc.ai[3] = -1f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.FlameWarmageBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedPlantBoss)
                return SpawnCondition.Cavern.Chance * 0.12f;
            else return 0f;
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Dance_Time_Slot = 2;

        const int State_Dance = 0;
        const int State_Spell = 1;
        const int State_Cast = 2;
        const int State_Still = 3;

        public float AI_State {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public float AI_SpellTime {
            get { return npc.ai[AI_Dance_Time_Slot]; }
            set { npc.ai[AI_Dance_Time_Slot] = value; }
        }

        public override void AI() {
            if (AI_State == State_Dance) {
                AI_Timer++;
                float distance = 1200f;
                Player p;

                for (int k = 0; k < 200; k++) {
                    p = Main.player[k];
                    if (p.active) {
                        if (npc.WithinRange(p.Center, distance)) {

                        }
                    }
                }

                npc.TargetClosest(true);
                if (AI_Timer >= 120) {
                    AI_State = State_Spell;
                    AI_Timer = 0;
                }
            } else if (AI_State == State_Spell) {
                AI_Timer++;
                if (AI_Timer == 10 && Main.netMode != 1) {
                    Vector2 playerpos = Main.player[npc.target].Center;
                    playerpos.Y -= 5;
                    int proj = Projectile.NewProjectile(playerpos, Vector2.Zero, ModContent.ProjectileType<Projectiles.Magic.FlameWarMageProj>(), npc.damage, 0f);
                }

                if (AI_Timer >= 240) {
                    AI_Timer = 0;
                    AI_State = State_Dance;
                }
            } else {
                AI_Timer++;
                if (AI_Timer >= 120) {
                    AI_State = State_Dance;
                    AI_Timer = 0;
                }
            }
        }

        const int Frame_Cast = 6;
        const int Frame_Spell = 5;
        const int Frame_Still = 0;
        const int Frame_Dance_Offset = 0;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;

            if (AI_State == State_Cast) {
                npc.frame.Y = Frame_Cast * frameHeight;
            } else if (AI_State == State_Spell) {
                AI_SpellTime++;
                if (AI_SpellTime < 55) {
                    npc.frame.Y = Frame_Spell * frameHeight;
                } else {
                    npc.frame.Y = Frame_Cast * frameHeight;
                }
                if (AI_SpellTime >= 120) {
                    AI_SpellTime = 0;
                }
            } else if (AI_State == State_Dance) {
                if (npc.frameCounter >= 49 - 1) npc.frameCounter = 0;
                else npc.frameCounter++;
                npc.frame.Y = ((int) npc.frameCounter / 10 + Frame_Dance_Offset) * frameHeight;
            } else if (AI_State == State_Still) {
                npc.frame.Y = Frame_Still * frameHeight;

            }
        }

        public override void NPCLoot() {
            if (Main.rand.Next(18) == 0) Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Magic.IT>());
        }
    }
}
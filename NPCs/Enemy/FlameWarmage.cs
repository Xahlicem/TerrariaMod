using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
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
            bannerItem = mod.ItemType<Items.Banners.FlameWarmageBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedPlantBoss){
            return SpawnCondition.Cavern.Chance * 0.2f;}
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
                if (AI_Timer >= 60) {
                    AI_State = State_Spell;
                    AI_Timer = 0;
                }
            } else if (AI_State == State_Spell) {
                AI_Timer++;
                if (AI_Timer == 10 && Main.netMode != 1) {
                    Vector2 playerpos = Main.player[npc.target].Center;
                    playerpos.Y -= 5;
                    int proj = Projectile.NewProjectile(playerpos, Vector2.Zero, mod.ProjectileType<Projectiles.Magic.FlameMageProj>(), npc.damage, 0f);
                }

                if (AI_Timer >= 120) {
                    AI_Timer = 0;
                    AI_State = State_Dance;
                }
            } else {
                AI_Timer++;
                if (AI_Timer >= 60) {
                    AI_State = State_Dance;
                    AI_Timer = 0;
                }
            }
        }

        const int Frame_Cast = 6;
        const int Frame_Spell = 5;
        const int Frame_Dance_1 = 0;
        const int Frame_Dance_2 = 1;
        const int Frame_Dance_3 = 2;
        const int Frame_Dance_4 = 3;
        const int Frame_Dance_5 = 4;

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
                npc.frameCounter++;
                if (npc.frameCounter < 10) {
                    npc.frame.Y = Frame_Dance_1 * frameHeight;
                } else if (npc.frameCounter < 20) {
                    npc.frame.Y = Frame_Dance_2 * frameHeight;
                } else if (npc.frameCounter < 30) {
                    npc.frame.Y = Frame_Dance_3 * frameHeight;
                } else if (npc.frameCounter < 40) {
                    npc.frame.Y = Frame_Dance_4 * frameHeight;
                } else if (npc.frameCounter < 50) {
                    npc.frame.Y = Frame_Dance_5 * frameHeight;
                } else {
                    npc.frameCounter = 0;
                }
            } else if (AI_State == State_Still) {
                npc.frame.Y = Frame_Dance_1 * frameHeight;

            }
        }

        public override void NPCLoot() {
            if (Main.rand.Next(15) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Magic.IT>());
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 7.5f / magnitude;

        }
        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 0.01f / magnitude;

            return vector;
        }
    }
}
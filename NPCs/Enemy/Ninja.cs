using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    // This ModNPC serves as an example of a complete AI example.
    public class Ninja : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ninja");
            Main.npcFrameCount[npc.type] = 15; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults() {
            npc.aiStyle = 3;
            aiType = NPCID.ChaosElemental;
            animationType = NPCID.ChaosElemental;

            NPC clone = new NPC();
            clone.CloneDefaults(NPCID.ChaosElemental);
            npc.width = clone.width;
            npc.height = clone.height;
            npc.HitSound = clone.HitSound;
            npc.DeathSound = clone.DeathSound;
            npc.knockBackResist = clone.knockBackResist;

            npc.damage = 18;
            npc.defense = 5;
            npc.lifeMax = 60;
            npc.value = 100f;
            clone = null;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.OverworldNightMonster.Chance * 0.2f;
        }

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }

        public override void AI() {
            npc.TargetClosest(true);
            float distance = Main.player[npc.target].Distance(npc.Center);
            if ((npc.life > npc.lifeMax * 0.4 || !npc.HasValidTarget) && distance > 100) {
                npc.alpha = 200;
                if (distance < 125 && distance > 100 && npc.ai[2] != 0) {
                    Utils.PoofOfSmoke(npc.Center);
                    if (Main.netMode != 1) {
                        int proj = Projectile.NewProjectile(npc.Center, GetVelocity(Main.player[npc.target]), ProjectileID.Shuriken, npc.damage / 4, 0f);
                        Main.projectile[proj].friendly = false;
                        Main.projectile[proj].hostile = true;
                    }
                    npc.netUpdate = true;
                    npc.ai[2] = 0;
                    npc.alpha = 0;
                } else if (distance > 125) npc.ai[2] = 1;
            } else {
                npc.ai[2] = 1;
                npc.alpha = 0;
            }
        }

        public override void NPCLoot() {
            Utils.PoofOfSmoke(npc.Center);
            if (Main.rand.Next(10) == 0) {
                switch (Main.rand.Next(3)) {
                    case 0:
                        Item.NewItem(npc.Center, new Vector2(npc.width, npc.height), ItemID.NinjaHood);
                        break;
                    case 1:
                        Item.NewItem(npc.Center, new Vector2(npc.width, npc.height), ItemID.NinjaPants);
                        break;
                    case 2:
                        Item.NewItem(npc.Center, new Vector2(npc.width, npc.height), ItemID.NinjaShirt);
                        break;
                }
            }
            Item.NewItem(npc.Center, new Vector2(npc.width, npc.height), ItemID.Shuriken, Main.rand.Next(4, 10));
        }

        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 12.5f / magnitude;

            return vector;
        }
    }
}
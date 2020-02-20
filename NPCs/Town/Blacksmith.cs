using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DrakSolz.NPCs.Town {
    [AutoloadHead]
    public class Blacksmith : ModNPC {
        /*public override string Texture
        {
            get
            {
                return "DrakSolz/NPCs/Pilgrim";
            }
        }

        public override string[] AltTextures
        {
            get
            {
                return new string[] { "DrakSolz/NPCs/Pilgrim_Alt_1" };
            }
        }*/

        public override bool Autoload(ref string name) {
            name = "Blacksmith";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Blacksmith");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 3;
            NPCID.Sets.AttackTime[npc.type] = 40;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 15;
            npc.defense = 20;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage) {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++) {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Smoke);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            return true;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom) {
            foreach (Item i in Main.LocalPlayer.inventory) {
                if (i.type == ItemID.IronAnvil || i.type == ItemID.LeadAnvil) return true;
            }
            return false;
        }

        public override string TownNPCName() {
            switch (WorldGen.genRand.Next(5)) {
                case 0:
                    return "Andre";
                case 1:
                    return "Vamos";
                case 2:
                    return "Boldwin";
                case 3:
                    return "McDuff";
                default:
                    return "Lenigrast";
            }
        }

        public override string GetChat() {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            foreach (Item i in Main.LocalPlayer.inventory) {
                if (i.type == ModContent.ItemType<Items.Melee.Sword>()) chat.Add("That sword seems to have potential.");
                if (i.type == ModContent.ItemType<Items.Melee.SwordHilt>()) chat.Add("That sword hilt had so much potential.");
                if (i.type == ModContent.ItemType<Items.Misc.CoalRed>() || i.type == ModContent.ItemType<Items.Misc.CoalWhite>() ||
                    i.type == ModContent.ItemType<Items.Misc.CoalYellow>() || i.type == ModContent.ItemType<Items.Misc.CoalBlue>() ||
                    i.type == ModContent.ItemType<Items.Misc.CoalLord>()) {
                    return "How's about... you leave that coal with me? I'd give my left arm for a gem like that. .";
                }
            }
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.Next(4) == 0) {
                chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " that her confetti cannon is done?");
            }
            chat.Add("A toilsome journey, I wager.  You'll require good arms.");
            chat.Add("Let me smith y' weapons. I am a smith, such is my purpose.");
            chat.Add("Prithee, be careful. I don't want to see m' work squandered!");
            chat.Add("Weapons and protection are sturdy enough, by and large. But when overused, they'll eventually break.");
            chat.Add("I ought to fetch a new coal…");
            chat.Add("We've got a wild one here! Shape up! Shape up, I say!");
            chat.Add("I can forge weapons for you, for a fair price.");
            chat.Add("Don't get yourself killed, neither of us wants to see you go Hollow.");
            chat.Add("Well, hello again. You seem to be doing all right. Need anything forged?");
            chat.Add("If I have anything to offer, it's my smithing, and nothing more.");

            return chat.Get();
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = Language.GetText("Shop").Value;
            DrakSolzPlayer player = Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
            button2 = "Give Coal";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            if (firstButton) {
                shop = true;
            } else {
                foreach (Item i in Main.LocalPlayer.inventory) {
                    if (i.type == ModContent.ItemType<Items.Misc.CoalRed>()) {
                        DrakSolzPlayer modPlayer = (DrakSolzPlayer) Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
                        modPlayer.CoalRed = true;
                        Main.npcChatText = "Oh, my, what a brilliant coal!";
                        i.TurnToAir();
                    }
                    if (i.type == ModContent.ItemType<Items.Misc.CoalWhite>()) {
                        DrakSolzPlayer modPlayer = (DrakSolzPlayer) Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
                        modPlayer.CoalWhite = true;
                        Main.npcChatText = "This coal burns like a soul. Certainly lifts my spirits!";
                        i.TurnToAir();
                    }
                    if (i.type == ModContent.ItemType<Items.Misc.CoalYellow>()) {
                        DrakSolzPlayer modPlayer = (DrakSolzPlayer) Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
                        modPlayer.CoalYellow = true;
                        Main.npcChatText = "My, my. the coal of that peaceful giant... I miss the old bugger, I do. I'll be sure this coal is put to good use.";
                        i.TurnToAir();
                    }
                    if (i.type == ModContent.ItemType<Items.Misc.CoalBlue>()) {
                        DrakSolzPlayer modPlayer = (DrakSolzPlayer) Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
                        modPlayer.CoalBlue = true;
                        Main.npcChatText = "Well, I've never heard of a blue coal. I find it strangely fascinating.";
                        i.TurnToAir();
                    }
                    if (i.type == ModContent.ItemType<Items.Misc.CoalLord>()) {
                        DrakSolzPlayer modPlayer = (DrakSolzPlayer) Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
                        modPlayer.CoalLord = true;
                        Main.npcChatText = "This contains the power of the sun itself... Astounding! This is my life's work come to an end, no greater wares could be forged.";
                        i.TurnToAir();
                    }
                }
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
            shop.item[nextSlot++].SetDefaults(ItemID.CopperBar);
            if (NPC.downedBoss1) shop.item[nextSlot++].SetDefaults(ItemID.IronBar);
            if (NPC.downedBoss2) shop.item[nextSlot++].SetDefaults(ItemID.SilverBar);
            if (NPC.downedBoss3) shop.item[nextSlot++].SetDefaults(ItemID.GoldBar);
            shop.item[nextSlot++].SetDefaults(ItemID.WoodenArrow);
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Ranged.SlingshotStones>());
            if (Main.hardMode == false) {
                shop.item[nextSlot++].SetDefaults(ItemID.IronBroadsword);
                shop.item[nextSlot++].SetDefaults(ItemID.IronShortsword);
                shop.item[nextSlot++].SetDefaults(ItemID.Shuriken);
                shop.item[nextSlot++].SetDefaults(ItemID.IronBow);
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Ranged.ReinforcedSlingshot>());
            } else {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Melee.MorianBlade>());
                shop.item[nextSlot++].SetDefaults(ItemID.BookStaff);
                shop.item[nextSlot++].SetDefaults(ItemID.BoneGlove);
                shop.item[nextSlot++].SetDefaults(ItemID.CobaltShield);
                shop.item[nextSlot++].SetDefaults(ItemID.HellfireArrow);
            }
            if (NPC.downedSlimeKing) {
                shop.item[nextSlot++].SetDefaults(ItemID.SlimeStaff);
                shop.item[nextSlot++].SetDefaults(ItemID.AmethystStaff);
                shop.item[nextSlot++].SetDefaults(ItemID.BladedGlove);
            }
            if (NPC.downedBoss1) {
                shop.item[nextSlot++].SetDefaults(ItemID.ThrowingKnife);
                shop.item[nextSlot++].SetDefaults(ItemID.TaxCollectorsStickOfDoom);

            }
            if (NPC.downedBoss2) {
                shop.item[nextSlot++].SetDefaults(ItemID.PoisonedKnife);
                shop.item[nextSlot++].SetDefaults(ItemID.BoneArrow);
                shop.item[nextSlot++].SetDefaults(ItemID.DyeTradersScimitar);
            }
            if (NPC.downedBoss3) {
                shop.item[nextSlot++].SetDefaults(ItemID.BoneDagger);
                shop.item[nextSlot++].SetDefaults(ItemID.Javelin);
                shop.item[nextSlot++].SetDefaults(ItemID.UnholyArrow);
                shop.item[nextSlot++].SetDefaults(ItemID.FalconBlade);
            }
            if (modPlayer.CoalRed == true) {
                shop.item[nextSlot++].SetDefaults(ItemID.EnchantedSword);
                shop.item[nextSlot++].SetDefaults(ItemID.FlamingArrow);
                shop.item[nextSlot++].SetDefaults(ItemID.StarAnise);
            }
            if (modPlayer.CoalWhite == true) {
                shop.item[nextSlot++].SetDefaults(ItemID.Arkhalis);
                shop.item[nextSlot++].SetDefaults(ItemID.JestersArrow);
                shop.item[nextSlot++].SetDefaults(ItemID.BoneJavelin);
            }
            if (modPlayer.CoalYellow == true) {
                shop.item[nextSlot++].SetDefaults(ItemID.MagicalHarp);
                shop.item[nextSlot++].SetDefaults(ItemID.ChainGuillotines);
                shop.item[nextSlot++].SetDefaults(ItemID.VampireKnives);
                shop.item[nextSlot++].SetDefaults(ItemID.DD2LightningAuraT2Popper);
                shop.item[nextSlot++].SetDefaults(ItemID.IchorArrow);
            }
            if (modPlayer.CoalBlue == true) {
                shop.item[nextSlot++].SetDefaults(ItemID.MoonlordArrow);
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Magic.MoonGS>());
                shop.item[nextSlot++].SetDefaults(ItemID.TerraBlade);
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.Twink>());
            }
            if (modPlayer.CoalLord == true) {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.Titanite>());
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Ranged.DragonslayerGreatarrow>());
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
            damage = 25;
            knockback = 5f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
            projType = ProjectileID.Flames;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
            multiplier = 3f;
            randomOffset = 2f;
        }
        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight){
            itemWidth = 30;
            itemHeight = 30;
        }
        public override void DrawTownAttackSwing(ref Microsoft.Xna.Framework.Graphics.Texture2D item, ref int itemSize, ref float scale, ref Microsoft.Xna.Framework.Vector2 offset) {
            item = Main.itemTexture[ItemID.IronHammer];
            itemSize = 40;
            scale = 0.3f;
            offset.X += 10 * npc.direction;
        }
    }
}
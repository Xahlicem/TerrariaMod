using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.World.Generation;
using Terraria.ModLoader.IO;

namespace DrakSolz.Tiles {
    public class LotteryMachine : ModItem {

        public override void SetStaticDefaults () {
            Tooltip.SetDefault ("Grants increased damage to 'On Fire' effects.");
        }

        public override void SetDefaults () {

            item.width = 46;
            item.height = 46;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.LotteryMachineTile> ();
        }
    }

    public class LotteryMachineTile : ModTile {
        public override void SetDefaults () {
            Main.tileLighted[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom (TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile (Type);

            ModTranslation name = CreateMapEntryName ();
            name.SetDefault ("LotteryMachine");
            AddMapEntry (new Color (250, 250, 0), name);

            dustType = DustID.Dirt;
            disableSmartCursor = true;
            minPick = 10;
        }
        public override void NumDust (int i, int j, bool fail, ref int num) {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile (int i, int j, int frameX, int frameY) {
            Item.NewItem (i * 16, j * 16, 32, 16, ModContent.ItemType<Tiles.LotteryMachine> ());
        }

        public override bool PreDraw (int i, int j, SpriteBatch spriteBatch) {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            if (Main.canDrawColorTile (i, j)) {
                texture = Main.tileTexture[Type];
            } else {
                texture = Main.tileTexture[Type];
            }
            Vector2 zero = new Vector2 (Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen) {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw (texture, new Vector2 (i * 16 - (int) Main.screenPosition.X, j * 16 - (int) Main.screenPosition.Y) + zero, new Rectangle (tile.frameX, tile.frameY, 16, 16), Lighting.GetColor (i, j), 0f, default (Vector2), 1f, SpriteEffects.None, 1f);
            return false;
        }

        public override bool NewRightClick (int i, int j) {
            HitWire (i, j);
            Player player = Main.LocalPlayer;
                foreach (Item g in player.inventory) {
                     if (g.type == ItemID.GoldCoin) {
                        int r = (Main.rand.Next(3929));
                        Item.NewItem(player.position, player.width, player.height, r);
                        g.stack -= 1;
                        return true;
                    }
                }
            return false;
        }

        public override void MouseOver (int i, int j) {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<Tiles.LotteryMachine> ();
        }

        public override void HitWire (int i, int j) {
            int x = i - (Main.tile[i, j].frameX / 18) % 2;
            int y = j - (Main.tile[i, j].frameY / 18) % 2;
            for (int l = x; l < x + 2; l++) {
                for (int m = y; m < y + 2; m++) {
                    if (Main.tile[l, m] == null) {
                        Main.tile[l, m] = new Tile ();
                    }
                }
            }
            if (Wiring.running) {
                Wiring.SkipWire (x, y);
                Wiring.SkipWire (x, y + 1);
                Wiring.SkipWire (x + 1, y);
                Wiring.SkipWire (x + 1, y + 1);
            }
            NetMessage.SendTileSquare (-1, x, y + 1, 2);
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollLingeringFlame : SoulItem {
        public PyroScrollLingeringFlame() : base(80000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lingering Flame");
            Tooltip.SetDefault("Conjures a flame which explodes after a small delay.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 70;
            item.mana = 30;
            item.knockBack = 5f;
            item.shootSpeed = 1.0f;
            item.value = Item.buyPrice(0, 30, 0, 0);
            item.shoot = mod.ProjectileType<Projectiles.LingeringProj>();
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Magic.Pyro.PyroScrollProfanedFlame>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}
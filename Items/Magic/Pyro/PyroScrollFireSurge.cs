using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollFireSurge : SoulItem {
        public PyroScrollFireSurge() : base(12000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Surge");
            Tooltip.SetDefault("Pyromancy that conjures a constant bursting flame from your hand.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 16;
            item.useTime = 10;
            item.useAnimation = 10;
            item.mana = 5;
            item.knockBack = 2.5f;
			item.crit = 4;
            item.shootSpeed = 2.5f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.FireProj2>();
            item.autoReuse = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollCombustion>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            return false;
        }
    }
}
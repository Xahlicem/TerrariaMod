﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class ScrollHiddenBody : SoulItem {
        public ScrollHiddenBody() : base(2500) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hidden Body");
            Tooltip.SetDefault("Become Invisible.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 15;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 3600; i++);
            player.AddBuff(BuffID.Invisibility, 3600);
            player.AddBuff(ModContent.BuffType<Buffs.ScrollMana>(), +(360 * (int) (item.mana * player.manaCost)));
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Scroll>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}
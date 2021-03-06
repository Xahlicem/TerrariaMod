﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingAvarice : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Serpent Ring");
            Tooltip.SetDefault("increases souls gathered from enemies by 20%");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(1, 0, 00, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().Avarice += 2;
        }
    }
}
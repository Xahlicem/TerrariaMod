﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingMagicPower : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Scholar's Ring");
            Tooltip.SetDefault("20% increased magic damage");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 12, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.magicDamage += 0.20f;
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DesertSorceress {
    [AutoloadEquip(EquipType.Legs)]
    public class SorceressSkirt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Desert Sorceress Skirt");
            Tooltip.SetDefault("Clothing worn by Desert Sorceresses. So fashionable." +
                "\n+6% fire damage" +
                "\n+15% movement speed" +
                "\n+ decreases mana regen delay");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 10, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed += 0.15f;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.06f;
            player.manaRegenDelay -= 5;
        }
    }
}
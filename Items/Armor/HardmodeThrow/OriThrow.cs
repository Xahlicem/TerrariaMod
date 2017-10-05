using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class OriThrow : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Orichalcum Head Piece");
            Tooltip.SetDefault("+23% thrown damage" +
                "\n+12% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 2, 25);
            item.rare = 4;
            item.defense = 11;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.23f;
            player.thrownCrit += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Flower petals will fall on your target for extra damage ");
            player.onHitPetal = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
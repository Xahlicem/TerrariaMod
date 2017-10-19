using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.SilverKnight {
    [AutoloadEquip(EquipType.Head)]
    public class SilverKnightHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight Helmet");
            Tooltip.SetDefault("Apparel.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = -1;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player) {
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.SilverKnight.SilverKnightArmor>() && legs.type == mod.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Can't Stop The Rock" +
                "\nDefensive powers increased");
            player.statDefense += 10;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.WaterWalking] = true;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Titanite>(), 25);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
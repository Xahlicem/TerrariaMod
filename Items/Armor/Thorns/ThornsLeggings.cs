using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Thorns {
    [AutoloadEquip(EquipType.Legs)]
    public class ThornsLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Leggings of Thorns");
            Tooltip.SetDefault("Armor famed by Commander Kirk." +
                "\n+20% thorns" +
                "\n+15% increased thrown crit" +
                "\n+10% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 17;
        }

        public override void UpdateEquip(Player player) {
            player.thrownCrit += 15;
            player.moveSpeed += 0.10f;
            player.thorns += 0.20f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpikyBall, 250);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
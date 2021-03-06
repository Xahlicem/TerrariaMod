using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Crimson {
    [AutoloadEquip(EquipType.Body)]
    public class CrimsonRobe : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Crimson Robe");
            Tooltip.SetDefault("Increases fire damage by 5%");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.LavaBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}
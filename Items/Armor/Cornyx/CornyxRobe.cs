using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Cornyx {
    [AutoloadEquip(EquipType.Body)]
    public class CornyxRobe : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cornyx's Robe");
            Tooltip.SetDefault("Increases fire damage by 10%");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 22;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.10f;
        }
        public override void DrawHands(ref bool drawHands, ref bool drawArms){
            drawHands = true;
        }


        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.InfernoBar>(), 20);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}
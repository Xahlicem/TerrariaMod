using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Misc {
    public class ShadeSoul : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shade Soul");
            Tooltip.SetDefault("Contains the powers of the dark side of the moon!");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.RecallPotion);
            item.useTime = 120;
            item.useStyle = 4;
            item.maxStack = 1;
            item.rare = 0;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.GetModPlayer<XahlicemPlayer>().ChangeRace(XahlicemPlayer.Race.Shade);
            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType<Items.Craft.FirelinkShrineTile>());
            recipe.AddIngredient(mod.ItemType<Items.Misc.SoulVessel>());
            recipe.AddIngredient(ItemID.ShadowKey);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
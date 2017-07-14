using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace XahlicemMod.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class MoonlightHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded helmet.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 2;
            item.defense = 30;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MoonlightChest") && legs.type == mod.ItemType("MoonlightLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "trollface.jpg";
            player.meleeDamage *= 0.8f;
            player.thrownDamage *= 0.8f;
            player.rangedDamage *= 0.8f;
            player.magicDamage *= 0.8f;
            player.minionDamage *= 0.8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}


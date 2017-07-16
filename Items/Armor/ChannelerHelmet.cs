using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace XahlicemMod.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class ChannelerHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Description!"
                + "\n+20% Magic Damage"
                + "\n+20% Melee Damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 5000000;
            item.rare = 9;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage *= 1.2f;
            player.meleeDamage *= 1.2f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ChannelerRobe") && legs.type == mod.ItemType("ChannelerSkirt");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = ("Moonlight Prayer"
                + "\n+1 Accessory Slot"
                + "\n+Channeler's Perfect Dance");
            player.extraAccessorySlots += 1;
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


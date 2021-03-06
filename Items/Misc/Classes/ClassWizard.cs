using Terraria.ModLoader;

namespace DrakSolz.Items.Misc.Classes {
    public class ClassWizard: ClassItem {
        protected override string TEXT { get { return "A Wizard"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 0; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 0; } }
        protected override int ATT { get { return 10; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Wizard Rune");
            Tooltip.SetDefault("Consume to focus on attunement.");
        }

        public override bool ConsumeItem(Terraria.Player player) {
            //player.QuickSpawnItem()
            player.QuickSpawnItem(ModContent.ItemType<Items.Misc.ScrollCastLight>());
            return true;
        }
    }
}
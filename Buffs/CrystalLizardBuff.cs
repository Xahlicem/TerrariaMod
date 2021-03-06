using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class CrystalLizardBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Crystal Lizard");
            Description.SetDefault("\"A Crystal Lizard shines light and empowers you!\"");
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = player.GetModPlayer<DrakSolzPlayer>();
            player.magicCrit += (1 * modPlayer.Level / 10);
            player.thrownCrit += (1 * modPlayer.Level / 10);
            player.meleeCrit += (1 * modPlayer.Level / 10);
            player.rangedCrit += (1 * modPlayer.Level / 10);
            player.GetModPlayer<MPlayer>().pyromancyCrit += 5;
            player.allDamage += (0.0025f * modPlayer.Level);
            player.manaCost *= (((modPlayer.Level * 0.0025f) * -1) + 1.00f);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<DrakSolzPlayer>().CrystalPet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.CrystalLizardPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
                Projectile.NewProjectile(player.position.X + (float) (player.width / 2), player.position.Y + (float) (player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.CrystalLizardPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
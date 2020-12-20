using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Items.Weapons
{
    public class AeriteSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aerite Sword");
        }

        public override void SetDefaults()
        {
            item.damage = 61;
            item.melee = true;
            item.width = 56;
            item.height = 56;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.value = 22400;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = false;
        }

        public override void AddRecipes()
        {
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }
    }
}
using Nephobia.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Items.Weapons
{
    public class EaveSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eavestoc");
            Tooltip.SetDefault("50% chance to heal for 3% of the damage you inflict\n5% chance to inflict either Cursed Inferno or Shadowflames");
        }

        public override void SetDefaults()
        {
            item.damage = 67;
            item.width = 40;
            item.height = 40;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2.3f;
            item.shootSpeed = 2.75f;
            item.value = 22500;
            item.scale = 1f;
            item.rare = ItemRarityID.Yellow;
            item.useTurn = false;

            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item19;
            item.shoot = ModContent.ProjectileType<Eavestoc>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("VampiricBlood"), 3);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.PixieDust, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Items.Weapons
{
    public class VampiricBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampiric Blade");
            Tooltip.SetDefault("55% chance to heal for 10% of the damage you inflict");
        }

        public override void SetDefaults()
        {
            item.damage = 36;
            item.melee = true;
            item.width = 42;
            item.height = 42;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = 7600;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item19;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BatFang"), 6);
            recipe.AddIngredient(ItemID.Bone, 9);
            recipe.AddIngredient(mod.ItemType("VampiricBlood"), 3);
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextFloat() < .5500f)
            {
                if (!target.friendly)
                {
                    int lifeSteal = damage / 10;
                    player.statLife += lifeSteal;
                    player.HealEffect(lifeSteal);
                }
            }
        }
    }
}
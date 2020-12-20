using Nephobia.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Items.Weapons
{
    public class HealingSpell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome o' Medella");
            Tooltip.SetDefault("Restores life at a 1:2 ratio");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.value = 21500;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 15;
            item.noMelee = true;
            item.mana = 10;
            item.magic = true;
            item.rare = ItemRarityID.LightRed;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLife != player.statLifeMax; // Check if the player is already Max HP. If they are, they can't use the tome.
        }

        public override bool UseItem(Player player)
        {
            if (!player.HasBuff(94) && !player.HasBuff(21)) // If player DOESN'T have Potion Sickness or Mana Sickness...
            {
                player.statLife += 5;
                player.HealEffect(5); // Heal at a regular speed.
                Dust.NewDust(player.position + player.velocity, player.width, player.height, ModContent.DustType<HealthDust>());
                return true;
            }
            else // If they DO have any one of those...
            {
                player.statLife += 1;
                player.HealEffect(1); // Heal at a very slow speed, discouraging abusing the tome during boss fights.
                Dust.NewDust(player.position + player.velocity, player.width, player.height, ModContent.DustType<HealthDust>());
                return true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.PixieDust, 5);
            recipe.AddIngredient(ItemID.Mushroom, 10);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			item.useStyle = 4;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noMelee = true;
			item.mana = 10;
			item.magic = true;
			item.rare = 4;
		}

		public override bool CanUseItem(Player player) {
			return player.statLife != player.statLifeMax; // Check if the player is already Max HP. If they are, they can't use the tome.
		}
		public override bool UseItem(Player player) {
			if (!player.HasBuff(94) && !player.HasBuff(21)) // If player DOESN'T have Potion Sickness or Mana Sickness...
			{
				player.statLife += 5;
				player.HealEffect(5); // Heal at a regular speed.
				return true;
			}
			else // If they DO have any one of those...
			{
				player.statLife += 1;
				player.HealEffect(1); // Heal at a very slow speed, discouraging abusing the tome during boss fights.
				return true;
			}
		}
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(531, 1);
			recipe.AddIngredient(520, 10);
			recipe.AddIngredient(501, 5);
			recipe.AddIngredient(5, 10);
			recipe.AddTile(101);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
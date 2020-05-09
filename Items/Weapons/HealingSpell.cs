using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EaveMod.Items.Weapons
{
	public class HealingSpell : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tome of Healing");
			Tooltip.SetDefault("Restores life at a 1:2 ratio");
		}

		public override void SetDefaults() 
		{
            item.width = 28;
            item.height = 30;
            item.value = 12500;
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
			return player.statLife != player.statLifeMax;
		}
		public override bool UseItem(Player player) {
			if (!player.HasBuff(21) || !player.HasBuff(94))
			{
				player.statLife += 5;
				player.HealEffect(5);
				return true;
			}
			else 
			{
				player.statLife += 1;
				player.HealEffect(1);
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
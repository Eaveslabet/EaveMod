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
			Tooltip.SetDefault("Restores life at a 1:2 ratio\nInflicts Mana Sickness upon use");
		}

		public override void SetDefaults() 
		{
            item.width = 28;
            item.height = 30;
            item.value = 12500;
			item.useStyle = 5;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noMelee = true;
			item.mana = 20;
			item.magic = true;
			item.rare = 8;
		}

		public override bool CanUseItem(Player player) {
			return player.statMana >= 20 && player.statLife != player.statLifeMax;;
		}
		public override bool UseItem(Player player) {
			if (!player.HasBuff(21))
			{
				player.statLife += 10;
				player.HealEffect(10);
				player.AddBuff(94, 20 * 30);
				return true;
			}
			else 
			{
				player.statLife += 2;
				player.HealEffect(2);
				player.AddBuff(94, 20 * 30);
				return true;
			}
		}
		        public override void AddRecipes()
        {
        }
	}
}
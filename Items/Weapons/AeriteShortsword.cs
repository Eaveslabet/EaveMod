using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Nephobia.Items.Weapons
{
	public class AeriteShortsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aerite Shortsword");
		}

		public override void SetDefaults() 
		{
			item.damage = 47;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 3;
			item.knockBack = 3;
			item.value = 15700;
			item.rare = 4;
			item.UseSound = SoundID.Item19;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }
	}
}
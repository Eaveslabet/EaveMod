using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EaveMod.Items
{
	public class BatFang : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
            item.width = 14;
            item.height = 18;
            item.maxStack = 999;
            item.value = 125;
		}

		        public override void AddRecipes()
        {
        }
	}
}
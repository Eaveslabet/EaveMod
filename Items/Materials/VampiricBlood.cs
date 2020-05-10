using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Nephobia.Items.Materials
{
	public class VampiricBlood : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
            item.width = 20;
            item.height = 22;
            item.maxStack = 999;
            item.value = 250;
		}

		        public override void AddRecipes()
        {
        }
	}
}
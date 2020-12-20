using Terraria.ModLoader;

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
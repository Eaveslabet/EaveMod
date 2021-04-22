using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Items.Placeable
{
    public class NephStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nephstone Block");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.NephStone>();
            item.width = 12;
            item.height = 12;
            item.value = 0;
        }
    }
}
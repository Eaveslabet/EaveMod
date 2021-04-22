using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Tiles
{
    public class NephStone : ModTile
    {
        public override void SetDefaults()
        {
            TileID.Sets.Stone[Type] = true;
            Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
            Main.tileShine2[Type] = false; // Modifies the draw color slightly.
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            dustType = 84;
            drop = ModContent.ItemType<Items.Placeable.NephStone>();
            soundType = SoundID.Dig;
            soundStyle = 1;
            mineResist = 1.5f;
            minPick = 65;
        }
    }
}
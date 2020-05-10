using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia
{
    public class ModGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(25) == 0)
            {
                if (npc.type == NPCID.CaveBat || npc.type == NPCID.JungleBat || npc.type == NPCID.Hellbat || npc.type == NPCID.GiantBat || npc.type == NPCID.IlluminantBat || npc.type == NPCID.IceBat || npc.type == NPCID.Lavabat || npc.type == NPCID.VampireBat || npc.type == NPCID.Vampire)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BatFang"));
                }
            }
        }
    }
}
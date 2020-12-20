using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Items.Tools
{
    public class EmptySyringe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Syringe");
            Tooltip.SetDefault("Used to siphon blood from vampiric creatures\nYes, it is necessary to be so involute!");
        }

        public override void SetDefaults()
        {
            item.damage = 1;
            item.crit = 0;
            item.melee = true;
            item.width = 30;
            item.height = 10;
            item.useTime = 15;
            item.useAnimation = 10;
            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 0;
            item.value = 5;
            item.UseSound = SoundID.Item19;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC npc, int damage, float knockBack, bool crit)
        {
            if (npc.type == NPCID.CaveBat || npc.type == NPCID.JungleBat || npc.type == NPCID.Hellbat || npc.type == NPCID.GiantBat || npc.type == NPCID.IlluminantBat || npc.type == NPCID.IceBat || npc.type == NPCID.Lavabat || npc.type == NPCID.VampireBat || npc.type == NPCID.Vampire || npc.type == NPCID.GiantFlyingFox)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("VampiricBlood"));
                for (int d = 0; d < 25; d++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 0f, -0.5f, 150, default(Color), 2f);
                    item.TurnToAir();
                }
            }
        }
    }
}
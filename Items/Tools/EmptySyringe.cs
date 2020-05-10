using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Nephobia.Items.Tools
{
	public class EmptySyringe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Syringe");
			Tooltip.SetDefault("Used to siphon blood from vampiric creatures");
		}

		public override void SetDefaults() 
		{
			item.damage = 1;
			item.melee = true;
            item.width = 30;
            item.height = 10;
			item.useTime = 30;
			item.useAnimation = 25;
            item.maxStack = 1;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 5;
			item.UseSound = SoundID.Item19;
			item.autoReuse = false;
		}

		        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(170, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }

		public override void OnHitNPC(Player player, NPC npc, int damage, float knockBack, bool crit)
        {
			if (npc.type == NPCID.CaveBat || npc.type == NPCID.JungleBat || npc.type == NPCID.Hellbat || npc.type == NPCID.GiantBat || npc.type == NPCID.IlluminantBat || npc.type == NPCID.IceBat || npc.type == NPCID.Lavabat || npc.type == NPCID.VampireBat || npc.type == NPCID.Vampire){
				if (Main.rand.Next(8) == 0){
					Item.NewItem(npc.getRect(), mod.ItemType("VampiricBlood"));
					// A pretty crappy way of implenting what I had originally wanted, but it works for now.
					// I had originally wanted the Syringe to "replace" itself with a filled variant, like the name implies.
					// Now it just has a chance to make the NPC drop some blood lol.
					for (int d = 0; d < 25; d++){
						Dust.NewDust(npc.position, npc.width, npc.height, 5, 0f, -0.5f, 150, default(Color), 1f);
					}
				}
			}
        }
	}
}
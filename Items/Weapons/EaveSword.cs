using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EaveMod.Items.Weapons
{
	public class EaveSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Eavestoc");
			Tooltip.SetDefault("50% chance to heal for 3% of the damage you inflict\nEven lower chance to inflict Cursed Inferno + Shadowflames\n'Blessed by a certain lil' vampire. Or cursed..?'");
		}

		public override void SetDefaults() 
		{
			item.damage = 71;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = 22500;
			item.rare = 8;
			item.UseSound = SoundID.Item19;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("VampiricBlood"), 6);
			recipe.AddIngredient(mod.ItemType("VampiricBroadsword"), 1);
			recipe.AddIngredient(520, 5);
			recipe.AddIngredient(1006, 6);
			recipe.AddIngredient(501, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool UseItem(Player player){
			//for (int d = 0; d < 10; d++){
			//	Dust.NewDust(player.position, player.width, player.height, 61, 0f, 0f, 150, default(Color), 1f);
			//	Dust.NewDust(player.position, player.width, player.height, 62, 0f, 0f, 150, default(Color), 1f);
			//}
			return true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			if(!target.friendly){
				if (Main.rand.NextFloat() < .5000f){
					int lifeSteal = damage / 30;
      				player.statLife += lifeSteal;
     				player.HealEffect(lifeSteal);
				}
			}

			if (Main.rand.Next(20) == 0){
            	target.AddBuff(BuffID.ShadowFlame, 10 * 30);
				target.AddBuff(BuffID.CursedInferno, 10 * 30);
				Main.PlaySound(2, (int)target.Center.X, (int)target.Center.Y, 20);
        	}
        }
	}
}
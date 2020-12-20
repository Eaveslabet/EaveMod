using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Nephobia.Dusts
{
    public class HealthDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity.Y = Main.rand.Next(-5, 5) * 0.2f;
            dust.velocity.X = Main.rand.Next(-5, 5) * 0.2f;
            dust.scale *= 1f;
            dust.noGravity = true;
        }

        public override bool MidUpdate(Dust dust)
        {
            if (dust.noLight)
            {
                return false;
            }

            float strength = dust.scale * 1.2f;
            if (strength > 1f)
            {
                strength = 1f;
            }
            Lighting.AddLight(dust.position, 0.05f * strength, 0.35f * strength, 0.15f * strength);
            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
            => new Color(lightColor.R, lightColor.G, lightColor.B, 25);
    }
}
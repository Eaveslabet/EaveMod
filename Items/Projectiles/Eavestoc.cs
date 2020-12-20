using Microsoft.Xna.Framework;
using Nephobia.Dusts;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Nephobia.Items.Projectiles
{
    public class Eavestoc : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eavestoc");
        }

        public float GetRandomNumber(float minimum, float maximum)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * (maximum - minimum) + minimum);
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        public float movementFactor
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[projectile.owner];

            if (p.statLife != p.statLifeMax)
            {
                if (!target.friendly)
                {
                    if (Main.rand.NextFloat() < .5000f) // 50% chance
                    {
                        int lifeSteal = damage / 30;
                        p.statLife += lifeSteal;
                        p.HealEffect(lifeSteal);
                    }
                }
            }

            if (Main.rand.NextFloat() < .0500f) // 5% chance
            {
                target.AddBuff(BuffID.CursedInferno, 10 * 30);
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 20);
            }

            if (Main.rand.NextFloat() < .0500f) // 5% chance
            {
                target.AddBuff(BuffID.ShadowFlame, 10 * 30);
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 20);
            }
        }

        public override void AI()
        {
            Player projOwner = Main.player[projectile.owner];
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 9f;
                    projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
                {
                    movementFactor -= 2.4f;
                }
                else
                {
                    movementFactor += 2.1f;
                }
            }
            projectile.position += projectile.velocity * movementFactor;
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(GetRandomNumber(130f, 140f));
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(GetRandomNumber(85f, 95f));
            }
            if (Main.rand.NextBool(3))
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, ModContent.DustType<EaveFlame>(), projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1f);
                dust.velocity += projectile.velocity * 1f;
                dust.velocity *= 0.2f;
            }
        }
    }
}
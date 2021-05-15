using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozelarMod2.Items
{
	public class GroovySword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("GroovySword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Get the grooves.");
		}

		public override void SetDefaults() 
		{
			item.damage = 100;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 100000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(Terraria.ID.ItemID.MeteoriteBar, 24);
			recipe.AddIngredient(Terraria.ID.ItemID.ShroomiteBar, 18);
			recipe.AddIngredient(Terraria.ID.ItemID.HellstoneBar, 12);
			recipe.AddTile(Terraria.ID.TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 5);
			recipe.AddTile(Terraria.ID.TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 10);
		}
	}
}
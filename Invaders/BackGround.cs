namespace Invaders;
using SFML.Graphics;
using SFML.System;

public class BackGround : Entity
{
    public override void Create(Scene scene)
    {
        base.Create(scene);
        //Instanciates the background assets.
        sprite.Texture = scene.assetManager.LoadTexture("SpaceShooterAssetPack_BackGrounds");
        sprite.TextureRect = new IntRect(128, 0, 128, 255);
        sprite.Scale = new Vector2f(3.5f, 3.5f);

    }

}
   
   
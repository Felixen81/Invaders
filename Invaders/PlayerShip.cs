using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class PlayerShip :Actor
{
    
    
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
    }


    public override void Create(Scene scene)
    {
        speed = 100f;
        base.Create(scene);

        Position = new Vector2f(212, 570);

        sprite.Texture = new Texture("assets/SpaceShooterAssetPack_Ships.png");
        sprite.TextureRect = new IntRect(8, 0, 8, 8);
        sprite.Origin = new Vector2f(4f, 4f);
        sprite.Scale = new Vector2f(3f, 3f);

    }
}
namespace Invaders;
using SFML.Graphics;
using SFML.System;

public class Explosion : Entity
{
    // How long the explotion will be visable on screen.
    private float timeBeforeDead; 
    
    public override void Update(Scene scene, float deltaTime)
    {
        if (timeBeforeDead >= 0)
        {
            timeBeforeDead -= deltaTime;
        }
        else
        {
            Dead = true;
        }
    }

    public override void Create(Scene scene)
    {
        //The Textures used is from https://gvituri.itch.io/space-shooter made by Gustavo Vituri
        sprite.Texture = new Texture("Assets/SpaceShooterAssetPack_Miscellaneous.png");
        sprite.TextureRect = new IntRect(80, 48, 8, 8);
        sprite.Scale = new Vector2f(3, 3);
    
        timeBeforeDead = 0.3f;
    }

    //Spawns it on the correct position
    public void Explode(Scene scene, Invader invader)
    {
        sprite.Position = invader.Position;
        scene.Spawn(this);
    }
}
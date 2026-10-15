using System.Reflection.PortableExecutable;

namespace Invaders;
using SFML.Graphics;
using SFML.System;

public class Bullet :Actor
{

    //Int to check the current bullets shot direction.
    private int bulletDirection;

    public override void Create(Scene scene)
    {
        //Sets desired sprite from desired spritesheet.
        sprite.Texture = new Texture("Assets/SpaceShooterAssetPack_Miscellaneous.png");
        sprite.TextureRect = new IntRect(43, 16, 3, 4);
        sprite.Origin = new Vector2f(1.5f, 2f);
        sprite.Scale = new Vector2f(3f, 3f);
    }

    public override void Update(Scene scene, float deltaTime)
    {
        //Checks if the player has shot the bullet.
        if (enemy == false)
        {
            Position += new Vector2f(0, -1) * (speed * deltaTime);
            speed = 210f;
        }
        //Checks if the Invader shot the bullet.
        if (enemy == true)
        {
            Position += DirectionVector2F(bulletDirection) * (speed * deltaTime);
            speed = 110f;
        }

        OutsideofScreen();
        
        
    }

    //Kills any bullets outside of the screen.
    private void OutsideofScreen()
    {
        //top
        if (Position.Y < 0)
        {
            Dead = true;
        }
         //bottom
        if (Position.Y > 600)
        {
            Dead = true;
        }
        //left side
        if (Position.X < 0)
        {
            Dead = true;
        }
        //Right side
        if (Position.X > 500)
        {
            Dead = true;
        }
    }
    
    //Creates that uses the same rotation adn direction that made it.
    public void Shoot(Scene scene, Actor actor)
    {
        //Spawns/instatiates the bullet in scene when shot.
        scene.Spawn(this);
        
        sprite.Rotation = actor.sprite.Rotation;
        //Sets the bulletdirection depending on where the actor is rotated.
        bulletDirection = actor.direction;

    }
}
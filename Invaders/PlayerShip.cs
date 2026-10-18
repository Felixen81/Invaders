using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders;

public class PlayerShip :Actor
{
    //This float is being used to check if the player should take damage or not.
    private float invunrable;
    
    
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);

        if (timebetweenShot >= 0)
        {
            timebetweenShot -= deltaTime;
        }
        //Cooldown of being imortal.
        if (invunrable >=  0)
        {
            invunrable -= deltaTime;
        }
        
        
        //"Is (visibly) immortal for a short time after taking damage."
        if (invunrable > 0)
        {
            sprite.Color = Color.Red;
        }
        else
        {
            sprite.Color = Color.White;
        }
        
        

         //The input for when player is shooting the bullets.
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && timebetweenShot <= 0)
        {
            Bullet bullet1 = new Bullet();
            bullet1.enemy = false;
            bullet1.Shoot(scene, this);
            bullet1.Position = new Vector2f(Position.X + 7f,Position.Y + 15f);

            Bullet bullet2 = new Bullet();
            bullet2.enemy = false;
            bullet2.Shoot(scene, this);
            bullet2.Position = new Vector2f(Position.X -7f, Position.Y + 15f);

            timebetweenShot = 0.5f;
        }
        
        
        
        //This part of code is so the player can't leave the scene window.
        // Makes the player unable to leave the screen on the X position
        Position = MathF.Floor(Position.X) switch
        {
            < 12 => new Vector2f(12, Position.Y), // 20
            >= 388 => new Vector2f(388, Position.Y), // 396
            _ => Position
        };
        // Makes the player unable to leave the screen on the Y position
        Position = MathF.Floor(Position.Y) switch
        {
            < 12 => new Vector2f(Position.X, 12), 
            >= 588 => new Vector2f(Position.X, 588), 
            _ => Position
        };
        
    }
    
    //Create function to spawn and give the playership it's values.
    public override void Create(Scene scene)
    {
        speed = 100f;
        //sets spawn position when instanciated.
        Position = new Vector2f(212, 570);
        enemy = false;
        base.Create(scene);

        //Chooses the right texture.
        sprite.Texture = new Texture("assets/SpaceShooterAssetPack_Ships.png");
        sprite.TextureRect = new IntRect(8, 0, 8, 8);
        //origin
        sprite.Origin = new Vector2f(4f, 4f);
        sprite.Scale = new Vector2f(3f, 3f);

    }

    
    public override void Destroy(Scene scene)
    {
        base.Destroy(scene);
        invunrable = 1f;
    }

    //Picks a direction depending on user input.
    protected override int ChoseDirection(Scene scene)
    {
        int dir = direction;
        if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right)) 
        {
            dir = 0; 
            isMoving = true;
            sprite.TextureRect = new IntRect(0, 0, 8, 8);
        } 
        else if (Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.Down)) 
        {
            dir = 1; 
            isMoving = true;
            sprite.TextureRect = new IntRect(8, 0, 8, 8);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Up)) 
        {
            dir = 2; 
            isMoving = true;
            sprite.TextureRect = new IntRect(8, 0, 8, 8);
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
        {
            dir = 3;
            isMoving = true;
            sprite.TextureRect = new IntRect(16, 0, 8, 8);
        }
        
        return dir;
    }
    
    
    //Collision with enemy
    protected override void CollidedWithEntity(Scene scene, Entity entity)
    {
        // Checks if it is an enemy
        if (entity.enemy)
        {
            // Checks if player is immortal
            if (invunrable <= 0)
            {
                
                // Makes the player immortal again
                Destroy(scene); 
                // Checks if it was an invader
                if (entity is Invader)
                {
                    // Makes the invader explode
                    entity.Destroy(scene); 
                }
                // Makes the entity that was collided with set to dead.
                entity.Dead = true; 
            
                // Lose health
                scene.eventManager.PublishLoseHealth(1);
            }
        }
    
    }
    
}
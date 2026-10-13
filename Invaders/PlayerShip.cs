using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders;

public class PlayerShip :Actor
{
    private float invunrable;
    
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);

        //Cooldown of being imortal.
        if (invunrable >= 0)
        {
            invunrable -= deltaTime;
        }
    }
    
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
    
    //Picks a direction depending on user input.
    protected override int ChoseDirection(Scene scene)
    {
        int dir = direction;
        if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right)) 
        {
            dir = 0; 
            isMoving = true;
        } 
        else if (Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.Down)) 
        {
            dir = 1; 
            isMoving = true;
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Up)) 
        {
            dir = 2; 
            isMoving = true;
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left)) 
        {
            dir = 3; 
            isMoving = true;
        } 
        return dir;
    }
    
    

    protected override void CollidedWithEntity(Scene scene, Entity entity)
    {
       
    }
}
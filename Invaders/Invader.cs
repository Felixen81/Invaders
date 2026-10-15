namespace Invaders;
using SFML.Graphics;
using SFML.System;


public class Invader : Actor
{
    private float timeBetweenBullets; //The cooldown of invader shooting


    public Invader()
    {
        isMoving = true;
        
    }

    // If it leaves the bottom of the screen it will reappear on the top side
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        //if it leaves the bottom of the screen it should reappear outside but at the top the screen.
        //Same thing used from pacman to change sides, but it changed Y instead of X.
        //MathF is used here to round up the float values to its nearest whole number since we are updating in deltaTime.
        Position = MathF.Floor(Position.Y) switch
        {
            > 630 => new Vector2f(Position.X, -32),
            _ => Position
        };
            




    }


    public override void Create(Scene scene)
    {
        
        speed = 50f;
        enemy = true;
        base.Create(scene);
         //Takes the desired sprite from the sprite/texture map.
        sprite.Texture = new Texture("Assets/SpaceShooterAssetPack_Ships.png");
        sprite.TextureRect = new IntRect(8, 32, 8, 8);

        sprite.Origin = new Vector2f(4f, 4f);
        sprite.Rotation = 135;
        sprite.Scale = new Vector2f(3, 3);
        //Start direction.
        direction = 4;
       
        //TODO change 32 to -32
        //Gives a random x spawn position outside the screen.
        sprite.Position = new Vector2f(RandomSpawn() , 32);

    }

    
    //Chooses correct direction Invader should go.
    protected override int ChoseDirection(Scene scene)
    {
        int dir = direction;

        //If it bounces on the left side.
        if (Position.X <= 12f)
        {
            isMoving = true;
            sprite.Rotation = 135;
            dir = 4;
        }
        //if it bounces on the right side.
        else if(Position.X > 388f)
        {
            isMoving = true;
            sprite.Rotation = 225;
            dir = 5;
        }

        return dir;
    }

     //Randomly spawns the enemy outside of the screen.
    private int RandomSpawn()
    {
        Random random = new Random();
        int spawn = random.Next(10, 384);
        return spawn;
    }
    
    
    
//A collision check meant to check if the bullet fired is not an enemy (not its own bullet or other invader bullets)
    protected override void CollidedWithEntity(Scene scene, Entity entity)
    {
        if (entity is Bullet)
        {
            if (!entity.enemy)
            {
                Dead = true;
                if (entity is Bullet)
                {
                    Destroy(scene);
                    entity.Dead = true;
                }
            }
        }
    }


    public override void Destroy(Scene scene)
    {
        
        
    }
}
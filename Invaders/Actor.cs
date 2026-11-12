using SFML.System;
using SFML.Graphics;
namespace Invaders;

public class Actor :Entity
{
    //This is protected so we can't change the value of it only get it.
    protected float speed;
    
    //A float used to count the timebetweenShots in deltaTime.
    protected float timebetweenShot;

    protected int direction;
    //Bool to check if actor should move.
    protected bool isMoving; 
    //Public bool used for checking if the intersects are of type enemy.
     public bool enemy;
    
    
    //I will reset the actors in different ways, Player, Enemy,Bullet etc.
    //I am not resetting player evertime it gets hit. (the example game didn't reset after hit)
    protected Actor()
    {
        
    }
    
    //Virtual property to send Global bounds to all entities.
    public virtual FloatRect Bounds => sprite.GetGlobalBounds();
    
    //Updates the actor behavior.
    public override void Update(Scene scene, float deltaTime)
    {
        

        base.Update(scene, deltaTime);
      
        //Similar function to pacman, where it checks for any intersected bounds.
        //Bullets colliding with enemy, and enemy bullets colliding to Playership.
        foreach (Actor actor in scene.FindActorIntersects(Bounds))
        {
            CollidedWithActor(scene, actor);
        }
        
       
        //Gives the actor the right direction
        direction = ChoseDirection(scene);

        //Checks if the actor may move.
        if (!isMoving) 
        {
            return;
        }
        Position += DirectionVector2F(direction) * (speed * deltaTime);
        
    }
    
    
    
    

    //Different vectors used by the actors.
    //Since the actors will have different speeds and directions we keep it protected but static to be reached outside of class.
    //All actors may use this to get their directions correct.
    protected static Vector2f DirectionVector2F(int dir)
    {
        switch (dir)
        {
          case 0:
              return new Vector2f(1, 0);
          case 1:
              return new Vector2f(0, 1);
          case 2:
              return new Vector2f(0, -1);
          case 3:
              return new Vector2f(-1, 0);
          case 4:
              return new Vector2f(2, 1);
          case 5:
              return new Vector2f(-2, 1);
              
          
        }

        return new Vector2f(0, 0);
    }

    //Used in invader and playership differently.
    protected virtual int ChoseDirection(Scene scene)
    {
        return 0;
    }
    
    
    protected virtual void CollidedWithActor(Scene scene, Actor actor)
    {
        
    }
}
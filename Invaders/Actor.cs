using SFML.System;

namespace Invaders;

public class Actor :Entity
{
    //This is protected so we can't change the value of it only get it.
    protected float speed;
    protected float timebetweenShot;

    public int direction;
    //Bool to check if actor should move.
    protected bool isMoving; 
    
    
    //I will reset the actors in different ways, Player, Enemy,Bullet etc.
    //I am not resetting player evertime it gets hit. (the example game didn't reset after hit)
    protected Actor()
    {
        
    }
    //Updates the actor behavior.
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        //Gives the actor the right direction
        direction = ChoseDirection(scene);
        //Checks if the actor may move.
        
        if (!isMoving) 
        {
            return;
        }
        Position += DirectionVector2F(direction) * (speed * deltaTime);
        Console.WriteLine(Position);
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

    protected virtual int ChoseDirection(Scene scene)
    {
        return 0;
    }
}
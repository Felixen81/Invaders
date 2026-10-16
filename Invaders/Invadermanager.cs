namespace Invaders;
using SFML.System;
using SFML.Graphics;

public class Invadermanager
{
    // Both used for checking when the invader should be spawned
    public float timeBetweenInvaders;
    public float spawnTime = 5f;
 
    public Invadermanager()
    {
        // Makes a invader spawn at the start of the game
        timeBetweenInvaders = 0; 
    }

    public void InvaderManagerUpdate(Scene scene, float deltaTime)
    {
        spawnTime -= deltaTime/10; // Makes the spawnTime smaller and smaller over time
     
        // Makes the invader not spawn faster than 0.5 sec
        if (spawnTime <= 0.5f)
        {
            spawnTime = 0.5f;
        }
     
        // Maked timeBetweenInvaders smaller with time if its bigger than 0
        if (timeBetweenInvaders >= 0)
        {
            timeBetweenInvaders -= deltaTime;
        }
        // Makes the timeBetweenInvaders to spawnTime that is used to decide when the invader is spawned
        else
        {
            timeBetweenInvaders = spawnTime;
        }
    }
}
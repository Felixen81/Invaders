namespace Invaders;
using SFML.Graphics;
using SFML.System;

public class Scene
{
    private readonly List<Entity> entities;
    public readonly EventManager eventManager = new EventManager();
    public readonly AssetManager assetManager = new AssetManager();
    public readonly Invadermanager invadermanager = new Invadermanager();
    
    public Scene()
    {
        entities = new List<Entity>();
        Start();
    }

    public void Start()
    {
        entities.Clear();
        PlayerShip playerShip = new PlayerShip();
        Spawn(playerShip);
        
        GUI gui = new GUI();
        Spawn(gui);
        
        //Invader frequency.
        invadermanager.spawnTime = 5f;

    }

    
    //Liknande som i pacman.
    //Adds all entities from the list and runs a create function.
    public void Spawn(Entity entity)
    {
        
        entities.Add(entity);
        entity.Create(this);
    }

    
    
    //An UpdateAll that updates all entities in the scene.
    //Same way in pacman where it removes entities from scene for less lag.
    public void UpdateAll(float deltaTime)
    {
        invadermanager.InvaderManagerUpdate(this, deltaTime);

        //Spawns the invaders
        if (invadermanager.timeBetweenInvaders <= 0)
        {
            Invader invader = new Invader();
            Spawn(invader);
        }
        
        // Cycles through all entites and updates them
        for (int i = entities.Count - 1; i >= 0; i--)
        {
            Entity e = entities[i];
            e.Update(this, deltaTime);
        }

        // Clears any dead entities from the list so the game dosen't lag.
        for (int i = 0; i < entities.Count;)
        {
            Entity e = entities[i];
            if (e.Dead) entities.RemoveAt(i);
            else i++;
        }
        //Updates all the events.
        eventManager.UpdateEvents(this);
        
    }
    
    //Renders all entities in the scene.
    public void RenderAll(RenderTarget target)
    {
        
        for (int i = entities.Count-1; i >= 0; i--)
        {
            entities[i].Render(target);
        }
        
    }

    
    //Check if two entities intersects bounds through a IEnurmerable. 
    //Same way in pacman.
    public IEnumerable<Entity> FindEntityIntersects(FloatRect entityBounds)
    {
        int lastInList = entities.Count - 1;
        for (int i = lastInList; i >=0; i--)
        {
            Entity entity = entities[i];
            if(entity.Dead) continue;
            if (entity.Bounds.Intersects(entityBounds))
            {
                yield return entity;
            }
        }
    }
    
}

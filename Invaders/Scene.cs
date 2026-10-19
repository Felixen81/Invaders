namespace Invaders;
using SFML.Graphics;


public class Scene
{
    private readonly List<Entity> entities;
    public readonly EventManager eventManager = new EventManager();
    public readonly AssetManager assetManager = new AssetManager();
    public readonly Invadermanager invadermanager = new Invadermanager();
    //Made private only on background to only read new instance.
    private readonly BackGround backGround = new BackGround();
    
    public Scene()
    {
        entities = new List<Entity>();
        Start();
    }

    public void Start()
    {
        entities.Clear();
        //creates background separately.
        backGround.Create(this);
        PlayerShip playerShip = new PlayerShip();
        Spawn(playerShip);
        GUI gui = new GUI();
        Spawn(gui);
        //Invader frequency.
        invadermanager.spawnTime = 5;
        
    }
    
    
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
        
        // Cycles through all entities and updates them
        for (int i = entities.Count - 1; i >= 0; i--)
        {
            Entity e = entities[i];
            e.Update(this, deltaTime);
        }

        // Clears any dead entities from the list so the game doesn't lag.
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
        //Also renders separately.
        backGround.Render(target);
        
        for (int i = entities.Count-1; i >= 0; i--)
        {
            entities[i].Render(target);
        }
        
    }

    
    //Check if two entities intersects bounds through an Enumerable. 
    //Same way in pacman.
    public IEnumerable<Entity> FindEntityIntersects(FloatRect entityBounds)
    {
        //Last int is local variable.
        int lastInList = entities.Count - 1;
        for (int i = lastInList; i >=0; i--)
        {
            Entity entity = entities[i];
            //If something is dead it runs from the top again and checks the next entity.
            if(entity.Dead) continue;
            if (entity.Bounds.Intersects(entityBounds))
            {
                //A yield return is used to return entity.
                //uses a yield return to wait for next call on iteration.
                yield return entity;
            }
        }
    }
    
}

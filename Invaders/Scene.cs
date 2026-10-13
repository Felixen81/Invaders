namespace Invaders;
using SFML.Graphics;

public class Scene
{
    private readonly List<Entity> entities;
    public readonly EventManager eventManager = new EventManager();
    public readonly AssetManager assetManager = new AssetManager();
    
    public Scene()
    {
        entities = new List<Entity>();
        Start();
    }

    public void Start()
    {
        entities.Clear();
        PlayerShip playerShip = new PlayerShip();
        Invader invader = new Invader();
        Spawn(playerShip);
        Spawn(invader);
    }

    public void Spawn(Entity entity)
    {
        entities.Add(entity);
        entity.Create(this);
    }

    public void UpdateAll(float deltaTime)
    {
        
    }
    
    public void RenderAll(RenderTarget target)
    {
        for (int i = entities.Count-1; i >= 0; i--)
        {
            entities[i].Render(target);
        }
    }

    
    //Check if two entities intersects bounds through a for loop.
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

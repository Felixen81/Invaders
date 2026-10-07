namespace Invaders;
using SFML.Graphics;

public class Scene
{
    private readonly List<Entity> entities;
    public readonly EventManager eventManager = new EventManager();
    
    
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
    }

    public void Spawn(Entity entity)
    {
        entities.Add(entity);
        entity.Create(this);
    }


    public void RenderAll(RenderTarget target)
    {
        for (int i = entities.Count-1; i >= 0; i--)
        {
            entities[i].Render(target);
        }
    }
    
}

using SFML.System;
using SFML.Graphics;
namespace Invaders;

public class Entity
{
    //The Textures used is from https://gvituri.itch.io/space-shooter made by Gustavo Vituri.
    public readonly Sprite sprite;
    //Clearing entities in the list.
    public bool Dead;
    //Public bool used for checking if the intersects are of type enemy.
    public bool enemy;

    public Entity()
    {
        sprite = new Sprite();
    }
    
    //The position of the entity.
    public Vector2f Position
    {
        get
        {
            return sprite.Position;
        }
        set
        {
            sprite.Position = value;
        }
    }

    //Virtual property to send Global bounds to all entities.
    public virtual FloatRect Bounds => sprite.GetGlobalBounds();

    
    public virtual void Update(Scene scene, float deltaTime)
    {
        
        //Similar function to pacman, where it checks for any intersected bounds.
        //Bullets colliding with enemy, and enemy bullets colliding to Playership.
        foreach (Entity entity in scene.FindEntityIntersects(Bounds)
                     .Where(entity => !entity.Dead).Where(entity => entity is Actor))
        {
            CollidedWithEntity(scene, entity);
        }
        
    }

    public virtual void Create(Scene scene)
    {
        
    }

    public virtual void Destroy(Scene scene)
    {
        
    }

    protected virtual void CollidedWithEntity(Scene scene, Entity entity)
    {
        
    }

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }
}
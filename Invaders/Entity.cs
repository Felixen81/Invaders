using SFML.System;
using SFML.Graphics;
namespace Invaders;

public class Entity
{
    //The Textures used is from https://gvituri.itch.io/space-shooter made by Gustavo Vituri.

    public readonly Sprite sprite;
    public bool Dead;
    public bool enemy;

    public Entity()
    {
        sprite = new Sprite();
    }

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

    public virtual FloatRect Bounds => sprite.GetGlobalBounds();

    public virtual void Update(Scene scene, float deltaTime)
    {
        /*
        foreach (Entity entity in scene.FindEntityInterSects(Bounds))
        {
            CollideWithEntity(scene, entity);
        }
        */
    }

    public virtual void Create(Scene scene)
    {
        
    }

    public virtual void Destroy(Scene scene)
    {
        
    }

    public virtual void CollidedWithEntity(Scene scene, Entity entity)
    {
        
    }

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }
}
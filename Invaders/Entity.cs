using SFML.System;
using SFML.Graphics;
namespace Invaders;

public class Entity
{
    //The Textures used is from https://gvituri.itch.io/space-shooter made by Gustavo Vituri.
    public readonly Sprite sprite;
    //Clearing entities in the list.
    public bool Dead;
    

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
    
    
    public virtual void Update(Scene scene, float deltaTime)
    {
        
        
        
    }

    public virtual void Create(Scene scene)
    {
        
    }

    public virtual void Destroy(Scene scene)
    {
        
    }

    

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }
}
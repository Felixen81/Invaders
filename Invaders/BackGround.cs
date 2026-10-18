namespace Invaders;
using SFML.Graphics;
using SFML.System;

public class BackGround : Entity
{

    protected Sprite BackroundSprite;


    public override void Create(Scene scene)
    {
        base.Create(scene);
        //Instanciates the background assets.
        BackroundSprite = new Sprite();
        BackroundSprite.Texture = new Texture("assets/SpaceShooterAssetPack_BackGrounds.png");
        BackroundSprite.TextureRect = new IntRect(126, 0, 126, 255);
        BackroundSprite.Scale = new Vector2f(3.5f, 3.5f);

    }

}
   
   
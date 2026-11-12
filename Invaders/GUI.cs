namespace Invaders;
using SFML.Graphics;
using SFML.System;

public class GUI : Entity
{
    // Score variables
    private Text scoreTtf = new Text();
    private float currentScore;
    private float scorePerSec;
 
    // Health variables
    private int maxHealth = 3;
    private int currentHealth;
 
    public override void Update(Scene scene, float deltaTime)
    {
        // Increases the score
        currentScore += deltaTime; 
     
        // Checks if the player is dead
        // If true then run the Start function of scene that resets everything
        if (currentHealth <= 0)
        {
            scene.Start();
        }
    }
    
    public override void Create(Scene scene)
    {
        // Score, the font used is the same as the pacman game
        scoreTtf.CharacterSize = 14;
        scoreTtf.Font = scene.assetManager.LoadFont("pixel-font");
    
        // Health, The Textures used is from https://gvituri.itch.io/space-shooter made by Gustavo Vituri.
        sprite.Texture = new Texture("Assets/SpaceShooterAssetPack_Miscellaneous.png");
        sprite.Scale = new Vector2f(3, 3);
        currentHealth = maxHealth;

        // Subscribes to the LoseHealth event with PlayerHit.
        scene.eventManager.LoseHealth += PlayerHit; 

    }

    public override void Render(RenderTarget target)
    {
        // Score code checks for int when current score is rendered.
        scoreTtf.DisplayedString = $"Score: {(int)currentScore}";
        scoreTtf.Position = new Vector2f(15, 5);
    
        target.Draw(scoreTtf);
    
        // Health code same as pacman where health is displayed on screen.
        sprite.Position = new Vector2f(15, 570);
    
        // For example the game example made the healthbar the same sprite as the player so that's what I did.
        // Same way done in pacman.
        for (int i = 0; i < maxHealth; i++)
        {
            // Empty space in the tilemap (replaces the heart with an invisible sprite)
            sprite.TextureRect = i < currentHealth ? new IntRect(16, 0, 8, 8) 
                : new IntRect(32, 0, 8, 8);
            base.Render(target);
            // Makes the sprites not be on top of eachother with an offset.
            sprite.Position += new Vector2f(25, 0); 
        }
    }
    
    // Makes the player lose one health when this is called.
    private void PlayerHit(Scene scene, int amount)
    {
        currentHealth -= amount;
    }
}

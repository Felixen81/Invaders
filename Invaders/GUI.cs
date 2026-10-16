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
        currentScore += deltaTime; // Increases the score
     
        // Checks if the player is dead
        // If true then run the Start function of scene that resets everything
        if (currentHealth <= 0)
        {
            scene.Start();
        }
     
    }
    
    // Hoppas jag gjorde det tillräckligt annorlunda från pacman när jag skrev det
    public override void Create(Scene scene)
    {
        // Score, the font used is the same as the pacman game
        scoreTtf.CharacterSize = 14;
        scoreTtf.Font = scene.assetManager.LoadFont("pixel-font");
    
        // Health, The Textures used is from https://gvituri.itch.io/space-shooter made by Gustavo Vituri
        sprite.Texture = new Texture("Assets/SpaceShooterAssetPack_Miscellaneous.png");
        sprite.Scale = new Vector2f(3, 3);
        currentHealth = maxHealth;

        scene.eventManager.LoseHealth += PlayerHit; // Subscribes to the LoseHealth event with PlayerHit

    }

    public override void Render(RenderTarget target)
    {
        // Score code
        scoreTtf.DisplayedString = $"Score: {(int)currentScore}";
        scoreTtf.Position = new Vector2f(15, 5);
    
        target.Draw(scoreTtf);
    
        // Health code, Samma som pacman
        sprite.Position = new Vector2f(15, 570);
    
        // Exempel spelet visade flera player sprites som liv, så jag antog att det var det ni ville ha
        // Gjorde det på samma sätt som pacman
        for (int i = 0; i < maxHealth; i++)
        {
            // Empty space in the tilemap (replaces the heart with an invisible sprite)
            sprite.TextureRect = i < currentHealth ? new IntRect(16, 0, 8, 8) 
                : new IntRect(32, 0, 8, 8);
            base.Render(target);
            // Makes the sprites not be on top of eachother
            sprite.Position += new Vector2f(25, 0); 
        }
    }
    
    // Makes the player lose one health when this is called
    private void PlayerHit(Scene scene, int amount)
    {
        currentHealth -= amount;
    }
}

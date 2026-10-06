namespace Invaders;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Program
{
    //Public const used to get unchanged values. 
    public const int SceenWidth = 400;
    public const int SceenHeight = 600;

    static void Main(string[] args)
    {
        //Creates a popup window.
        using (var window = new RenderWindow(new VideoMode(SceenWidth, SceenHeight), "Space_Invader"))
        {
            //Closes the window
            window.Closed += (s, e) => window.Close();
        
            Clock clock = new Clock(); // Clock instance used for updating entities
            // Scene scene = new Scene();
        
            //Loop that plays when window is open.
            while (window.IsOpen)
            {
                window.DispatchEvents(); //Event that tells window to close.
                float deltaTime = MathF.Min(clock.Restart().AsSeconds(), 0.1f); 
                deltaTime = MathF.Min(deltaTime, 0.01f);
            
                // Update the entity positions
                //scene.UpdateAll(deltaTime);
                // Clears the window
                window.Clear(new Color(0, 0, 0));
                // Renders the entities with new positions
                //scene.RenderAll(window);
                // Display it
                window.Display();
            }
        }
    }
}
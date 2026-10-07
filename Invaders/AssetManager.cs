namespace Invaders;
using SFML.Graphics;

public class AssetManager
{
    //Reads strings with name assets.
    public static readonly string Assetpath = "assets";
    private readonly Dictionary<string, Texture> textures;
    private readonly Dictionary<string, Font> fonts;

    //Constructor
    public AssetManager()
    {
        textures = new Dictionary<string, Texture>();
        fonts = new Dictionary<string, Font>();
    }

    public Texture LoadTexture(string name)
    {
        //Loads textures from our assetpath with names that include png.
        return new Texture($"{Assetpath}/{name}.png");
    }
    //Loads Fonts from our assetpath with names that include .ttf returns  
    public Font LoadFont(string name)
    {
        return new Font($"{Assetpath}/{name}.ttf");
    }
    //Loads text where it find it from our assestpath.
    public string LoadText(string name)
    {
        return $"{Assetpath}/{name}.txt";
    }
    
    
    
}
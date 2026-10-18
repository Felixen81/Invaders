namespace Invaders;

public class EventManager
{
    //Delegate 
    public delegate void ValueChangedEvent(Scene scene, int value);

    public event ValueChangedEvent LoseHealth;
    private int healthlost;

    public void UpdateEvents(Scene scene)
    {
        if (healthlost != 0)
        {
            LoseHealth.Invoke(scene, healthlost);
            healthlost = 0;
        }
    }

    //The publisher for LoseHealthEvent
    public void PublishLoseHealth(int amount)
    {
        healthlost += amount;
    }




}
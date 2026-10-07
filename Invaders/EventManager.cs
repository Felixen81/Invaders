namespace Invaders;

public class EventManager
{
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

    public void PublishLoseHealth(int amount)
    {
        healthlost += amount;
    }




}
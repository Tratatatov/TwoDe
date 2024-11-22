
public abstract class State
{
    private StateSwitcher m_switcher;

    public StateSwitcher StateSwitcher => m_switcher;

    public State(StateSwitcher switcher)
    {
        m_switcher = switcher;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();

}

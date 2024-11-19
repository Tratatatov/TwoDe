using System.Collections.Generic;
using System.Linq;

public class StateSwitcher
{
    public List<State> States = new List<State>();

    private State m_currentState;
    public State CurrentState => m_currentState;

    public void SwitchState<TState>() where TState : State
    {
        m_currentState?.Exit();
        m_currentState = States.OfType<TState>().FirstOrDefault();
        m_currentState?.Enter();
    }
}
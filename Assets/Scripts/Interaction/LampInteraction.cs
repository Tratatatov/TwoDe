using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(SpriteRenderer))]
public class LampInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent m_interacted;
    [SerializeField] private Sprite m_interactionSprite;
    private Sprite m_startSprite;
    private SpriteRenderer m_spriteRenderer;
    private StateSwitcher m_stateSwitcher;
    public Transform Transform { get => transform; }

    public void ChangeSprite(Sprite sprite)
    {
        m_spriteRenderer.sprite = sprite;
    }

    public void Interact()
    {
        m_interacted?.Invoke();
    }

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        //m_stateSwitcher = GetComponent<Enemy>().StateSwitcher;
        m_startSprite = m_spriteRenderer.sprite;
    }

    private void Update()
    {

    }

    public void Highlight()
    {
        ChangeSprite(m_interactionSprite);
    }

    public void Unhighlight()
    {
        ChangeSprite(m_startSprite);
    }
}

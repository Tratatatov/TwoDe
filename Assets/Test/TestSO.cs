using UnityEngine;

public class TestSO : MonoBehaviour
{
    [SerializeField] private SOTest test;
    [field: SerializeField] private float valueTest;
    private void Construct(ref float test)
    {
        valueTest = test;
    }
    void Start()
    {
       valueTest = test.Speed;

    }

    void Update()
    {
    }
}

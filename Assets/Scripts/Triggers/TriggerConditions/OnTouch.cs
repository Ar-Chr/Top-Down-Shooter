using UnityEngine;

public class OnTouch : MonoBehaviour
{
    [SerializeField] private TriggerActionComposite genericActions;
    [SerializeField] private TriggerActionComposite<GameObject> gameObjectActions;

    public TriggerActionComposite GenericActions => genericActions;
    public TriggerActionComposite<GameObject> GameObjectActions => gameObjectActions;

    void OnTriggerEnter(Collider other)
    {
        genericActions.Execute();
        gameObjectActions.Execute(other.gameObject);
    }
}

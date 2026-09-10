using UnityEngine;

public class ScreenView : MonoBehaviour
{
    public string Id => _id;

    [SerializeField] private string _id;

    public virtual ScreenController Construct(EventManager eventManager)
    {
        return new ScreenController(this, eventManager);
    }

    public void OpenScreen()
    {
        gameObject.SetActive(true);
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}

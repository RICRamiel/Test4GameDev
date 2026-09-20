using UnityEngine;
using TMPro;

public class FirstFloorView : ScreenView
{
    [SerializeField] private TMP_Text _itemsText;

    public TMP_Text ItemsText => _itemsText;

    public override ScreenController Construct(EventManager eventManager)
    {
        return new FirstFloorUIController(this, eventManager);
    }
}
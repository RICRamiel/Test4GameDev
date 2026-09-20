using UnityEngine;
using static EventsProvider;

public class FirstFloorUIController : ScreenController
{
    private readonly FirstFloorView _view;

    public FirstFloorUIController(FirstFloorView view, EventManager eventManager) : base(view, eventManager)
    {
        _view = view;
        _eventManager.Subscribe<FirstFloorProgressChangedEvent>(OnProgressChanged);
    }

    public override void Open()
    {
        base.Open();

        _view.ItemsText.text = "Предметы: 0 / 3";
    }

    private void OnProgressChanged(
        FirstFloorProgressChangedEvent evt)
    {
        _view.ItemsText.text =
            $"Предметы: {evt.Collected} / {evt.Required}";
    }

    public override void Dispose()
    {
        _eventManager.Unsubscribe<FirstFloorProgressChangedEvent>(
            OnProgressChanged
        );

        base.Dispose();
    }
}
using ExitGames.Client.Photon;

namespace SpacewareCheats.Events
{
    public interface IOnEventEvent
    {
        bool OnEvent(EventData eventData);
    }
}

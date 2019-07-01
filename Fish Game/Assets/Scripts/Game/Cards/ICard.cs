namespace Assets.Scripts.Game.Cards
{
    public interface ICard
    {
        string Name { get; }
        string Description { get; }
        void Play();
        bool CanPlay();
    }
}

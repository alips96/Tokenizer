namespace TokenizerProject
{
    /// <summary>
    /// This interface is responsible for holdin ToInitialState method for every classes
    /// derived from this interface.
    /// </summary>
    public interface IGetBackToInitialState : IState
    {
        void ToInitialState();
    }
}

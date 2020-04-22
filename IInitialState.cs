namespace TokenizerProject
{
    /// <summary>
    /// This interface is the structure of the states.
    /// </summary>
    public interface IInitialState : IState
    {
        void ToFarsiCharState();
        void ToFarsiNomState();
        void ToEnglishCharState();
        void ToEnglishNomState();
    }
}

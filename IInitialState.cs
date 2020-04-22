namespace TokenizerProject
{
    /// <summary>
    /// This interface is the structure of the states.
    /// </summary>
    public interface IInitialState : IState
    {
        void ToDigitState();
        void ToSharpState();
        void ToSpecialTokenState();
        void ToFarsiCharState();
        void ToDigitDotState();
        void ToEnglishCharState();
    }
}

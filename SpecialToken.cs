namespace TokenizerProject
{
    public class SpecialToken : IState
    {
        MainForm mainForm;
        public SpecialToken(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToInitialState()
        {
            mainForm.currentState = mainForm.initialState;
        }

        public void UpdateState()
        {
            WriteCurrentTokenInList();
            ToInitialState();
        }

        private void WriteCurrentTokenInList()
        {
            mainForm.tokensList.Add(new Token(mainForm.currentToken, "Special Token"));
            mainForm.currentToken = null;
        }
    }
}

using System.Linq;

namespace TokenizerProject
{
    /// <summary>
    /// This class is the core of all states.
    /// </summary>
    public class InitialState : IInitialState
    {
        MainForm mainForm;
        public InitialState(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToEnglishCharState()
        {
            mainForm.currentState = mainForm.englishCharState;
        }

        public void ToFarsiCharState()
        {
            mainForm.currentState = mainForm.farsiCharState;
        }

        public void ToDigitState()
        {
            mainForm.currentState = mainForm.digitState;
        }

        public void ToSharpState()
        {
            mainForm.currentState = mainForm.sharpState;
        }

        public void ToSpecialTokenState()
        {
            mainForm.currentState = mainForm.specialTokenState;
        }

        public void ToDigitDotState()
        {
            mainForm.currentState = mainForm.digitDotState;
        }

        public void UpdateState()
        {
            CheckForInput();
        }

        private void CheckForInput()
        {
            if (mainForm.plainTextQueue.Count > 0)
            {
                int currentChar = mainForm.plainTextQueue.Dequeue(); //extracts the first element of queue.

                if (currentChar >= 1776 && currentChar <= 1785) //if it is a farsi number.
                {
                    ExtendCurrentToken();
                    //ToFarsiNomState();
                }
                else
                    if ((currentChar >= 1570 && currentChar <= 1607) || //if it is a farsi character.
                        currentChar == 1662 ||
                        currentChar == 1740)
                {
                    ExtendCurrentToken();
                    ToFarsiCharState();
                }
                else
                    if ((currentChar >= 65 && currentChar <= 90) || //if it is an english character.
                        (currentChar >= 97 && currentChar <= 122))
                {
                    ExtendCurrentToken();
                    ToEnglishCharState();
                }
                else
                    if (currentChar >= 48 && currentChar <= 57) //if it is an english number.
                {
                    ExtendCurrentToken();
                    //ToEnglishNomState();
                }
                else
                    if ((currentChar >= 33 && currentChar <= 47) ||  //if it is a special character.
                        (currentChar >= 58 && currentChar <= 64) ||
                        currentChar >= 91 && currentChar <= 96 ||
                        currentChar >= 123 && currentChar <= 126)
                {
                    ExtendCurrentToken();
                    WriteCurrentTokenInList();
                }
                else
                    if(currentChar == 32)
                {
                    mainForm.tokensLinkedList.RemoveFirst();
                }
            }
            else
            {
                mainForm.isFinished = true; // Stops the Main While of program.
            }
        }

        private void WriteCurrentTokenInList()
        {
            mainForm.tokensList.Add(new Token(mainForm.currentToken, "Special Token"));
            mainForm.currentToken = null;
        }

        private void ExtendCurrentToken()
        {
            if (mainForm.tokensLinkedList.First() != ' ')
            {
                mainForm.currentToken += mainForm.tokensLinkedList.First();
            }

            mainForm.tokensLinkedList.RemoveFirst();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TokenizerProject
{
    /// <summary>
    /// Almost every resources needed in this project are located in this class.
    /// </summary>
    public partial class MainForm : Form
    {
        //States
        public IState currentState;
        public InitialState initialState;
        public Digit digitState;
        public DigitDot digitDotState;
        public RealNumber realNumberState;
        public RealNumberDot realNumberDotState;
        public RealNumberDotDigit realNumberDotDigitState;
        public RealNumberDotDigitDot realNumberDotDigitDotState;
        public Sharp sharpState;
        public Hashtag hashtagState;
        public SpecialToken specialTokenState;
        public UnknownToken unknownTokenState;


        public FarsiCharState farsiCharState;
        public FarsiNomState farsiNomState;
        public EnglishCharState englishCharState;
        public EnglishNomState englishNomState;
        
        //Main Queue holding ascii codes
        public Queue<int> plainTextQueue = new Queue<int>();

        public bool isFinished = false;

        public string currentToken;
        public List<Token> tokensList = new List<Token>();
        public LinkedList<char> tokensLinkedList = new LinkedList<char>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonStartCalculation_Click(object sender, EventArgs e)
        {
            if(InputTextBox.Text != null)
            {
                SetupStateRefrences();
                StartCountingTokens();
            }
        }

        private void SetupStateRefrences()
        {
            currentState = new InitialState(this);
            initialState = new InitialState(this);
            digitState = new Digit(this);
            digitDotState = new DigitDot(this);
            realNumberState = new RealNumber(this);
            realNumberDotState = new RealNumberDot(this);
            realNumberDotDigitState = new RealNumberDotDigit(this);
            realNumberDotDigitDotState = new RealNumberDotDigitDot(this);

            farsiCharState = new FarsiCharState(this);
            farsiNomState = new FarsiNomState(this);
            englishCharState = new EnglishCharState(this);
            englishNomState = new EnglishNomState(this);
        }

        /// <summary>
        /// The whole story starts from here.
        /// </summary>
        private void StartCountingTokens()
        {
            //Convert the chars into Ascii codes and put them in the main queue and the linked list.
            for (int i = 0; i < InputTextBox.Text.Length; i++)
            {
                plainTextQueue.Enqueue(Convert.ToInt32(InputTextBox.Text[i]));
                tokensLinkedList.AddLast(InputTextBox.Text[i]);
            }

            while (!isFinished)
            {
                currentState.UpdateState();
            }

            PrintResults();
        }

        /// <summary>
        /// Print results is the final step.
        /// </summary>
        private void PrintResults()
        {
            ResultText.Text = null;

            foreach (Token token in tokensList)
            {
                ResultText.Text += token.TokenValue + " is a(n) " + token.TokenType + "\n";
            }
        }
    }
}

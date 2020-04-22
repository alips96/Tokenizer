namespace TokenizerProject
{
    public class Token
    {
        string tokenValue;
        string tokenType;

        public string TokenValue
        {
            get
            {
                return tokenValue;
            }
        }

        public string TokenType
        {
            get
            {
                return tokenType;
            }
        }

        public Token(string _tokenValue,string _tokenType)
        {
            tokenValue = _tokenValue;
            tokenType = _tokenType;
        }
    }
}

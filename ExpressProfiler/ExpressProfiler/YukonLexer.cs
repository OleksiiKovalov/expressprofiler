//Traceutils assembly
//writen by Locky, 2009.
using System;
using System.Drawing;
using System.Text;

namespace ExpressProfiler
{
    public class YukonLexer
    {
        public enum TokenKind
        {
            tkComment, tkDatatype,
            tkFunction, tkIdentifier, tkKey, tkNull, tkNumber, tkSpace, tkString, tkSymbol, tkUnknown, tkVariable, tkGreyKeyword, tkFuKeyword
        }

        private enum SqlRange { rsUnknown, rsComment, rsString }
        private readonly Sqltokens m_Tokens = new Sqltokens();

        const string IdentifierStr = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_#$";
        private readonly char[] m_IdentifiersArray = IdentifierStr.ToCharArray();
        const string HexDigits = "1234567890abcdefABCDEF";
        const string NumberStr = "1234567890.-";
        private int m_StringLen;
        private int m_TokenPos;
        private string m_Token = "";
        private TokenKind m_TokenId;
        private string m_Line;
        private int m_Run;

        private TokenKind TokenId
        {
            get { return m_TokenId; }
        }

        private string Token { get { /*int len = m_Run - m_TokenPos; return m_Line.Substring(m_TokenPos, len);*/return m_Token; } }
        private SqlRange Range { get; set; }

        private char GetChar(int idx)
        {
            return idx >= m_Line.Length ? '\x00' : m_Line[idx];
        }
        public string StandardSql(string sql)
        {
            StringBuilder result = new StringBuilder();
            Line = sql;
            while (TokenId != TokenKind.tkNull)
            {
                switch (TokenId)
                {
                    case TokenKind.tkNumber:
                    case TokenKind.tkString: result.Append("<??>"); break;
                    default: result.Append(Token); break;
                }
                Next();
            }
            return result.ToString();
        }
        public YukonLexer() { Array.Sort(m_IdentifiersArray); }
        public void FillRichEdit(System. Windows.Forms.RichTextBox rich, string value)
        {

            rich.Text = "";
            Line = value;

            RTFBuilder sb = new RTFBuilder { BackColor = rich.BackColor };
            while (TokenId != TokenKind.tkNull)
            {
                Color forecolor;
                switch (TokenId)
                {
                    case TokenKind.tkKey: forecolor = Color.Blue;
                        break;
                    case TokenKind.tkFunction: forecolor = Color.Fuchsia; break;
                    case TokenKind.tkGreyKeyword: forecolor = Color.Gray; break;
                    case TokenKind.tkFuKeyword: forecolor = Color.Fuchsia; break;
                    case TokenKind.tkDatatype: forecolor = Color.Blue; break;
                    case TokenKind.tkNumber: forecolor = Color.Red; break;
                    case TokenKind.tkString: forecolor = Color.Red; break;
                    case TokenKind.tkComment: forecolor = Color.DarkGreen;
                        break;
                    default: forecolor = Color.Black; break;
                }
                sb.ForeColor = forecolor;
                if (Token == Environment.NewLine || Token == "\r" || Token == "\n")
                {
                    sb.AppendLine();
                }
                else
                {
                    sb.Append(Token);
                }
                Next();
            }
            rich.Rtf = sb.ToString();
        }

        private string Line
        {
            set { Range = SqlRange.rsUnknown; m_Line = value; m_Run = 0; Next(); }
        }
        private void NullProc() { m_TokenId = TokenKind.tkNull; }
        // ReSharper disable InconsistentNaming
        private void LFProc() { m_TokenId = TokenKind.tkSpace; m_Run++; }
        private void CRProc() { m_TokenId = TokenKind.tkSpace; m_Run++; if (GetChar(m_Run) == '\x0A')m_Run++; }
        // ReSharper restore InconsistentNaming

        private void AnsiCProc()
        {
            switch (GetChar(m_Run))
            {
                case '\x00': NullProc(); break;
                case '\x0A': LFProc(); break;
                case '\x0D': CRProc(); break;

                default:
                    {
                        m_TokenId = TokenKind.tkComment;
                        char c;
                        do
                        {
                            if (GetChar(m_Run) == '*' && GetChar(m_Run + 1) == '/')
                            {
                                Range = SqlRange.rsUnknown; m_Run += 2; break;
                            }
                            m_Run++;
                            c = GetChar(m_Run);
                        }
                        while (!(c == '\x00' || c == '\x0A' || c == '\x0D'));
                        break;
                    }



            }
        }

        private void AsciiCharProc()
        {
            if (GetChar(m_Run) == '\x00') { NullProc(); }
            else
            {
                m_TokenId = TokenKind.tkString;
                if (m_Run > 0 || Range != SqlRange.rsString || GetChar(m_Run) != '\x27')
                {
                    Range = SqlRange.rsString;
                    char c;
                    do { m_Run++; c = GetChar(m_Run); } while (!(c == '\x00' || c == '\x0A' || c == '\x0D' || c == '\x27'));
                    if (GetChar(m_Run) == '\x27')
                    {
                        m_Run++;
                        Range = SqlRange.rsUnknown;
                    }
                }
            }
        }

        private void DoProcTable(char chr)
        {
            switch (chr)
            {
                case '\x00': NullProc(); break;
                case '\x0A': LFProc(); break;
                case '\x0D': CRProc(); break;
                case '\x27': AsciiCharProc(); break;

                case '=': EqualProc(); break;
                case '>': GreaterProc(); break;
                case '<': LowerProc(); break;
                case '-': MinusProc(); break;
                case '|': OrSymbolProc(); break;
                case '+': PlusProc(); break;
                case '/': SlashProc(); break;
                case '&': AndSymbolProc(); break;
                case '\x22': QuoteProc(); break;
                case ':':
                case '@': VariableProc(); break;
                case '^':
                case '%':
                case '*':
                case '!': SymbolAssignProc(); break;
                case '{':
                case '}':
                case '.':
                case ',':
                case ';':
                case '?':
                case '(':
                case ')':
                case ']':
                case '~': SymbolProc(); break;
                case '[': BracketProc(); break;
                default:
                    DoInsideProc(chr); break;

            }
        }

        private void DoInsideProc(char chr)
        {

            if ((chr >= 'A' && chr <= 'Z') || (chr >= 'a' && chr <= 'z') || (chr == '_') || (chr == '#')) { IdentProc(); return; }
            if (chr >= '0' && chr <= '9') { NumberProc(); return; }
            if ((chr >= '\x00' && chr <= '\x09') || (chr >= '\x0B' && chr <= '\x0C') || (chr >= '\x0E' && chr <= '\x20')) { SpaceProc(); return; }
            UnknownProc();
        }

        private void SpaceProc()
        {
            m_TokenId = TokenKind.tkSpace;
            char c;
            do { m_Run++; c = GetChar(m_Run); }
            while (!(c > '\x20' || c == '\x00' || c == '\x0A' || c == '\x0D'));
        }

        private void UnknownProc()
        {
            m_Run++;
            m_TokenId = TokenKind.tkUnknown;
        }

        private void NumberProc()
        {
            m_TokenId = TokenKind.tkNumber;
            if (GetChar(m_Run) == '0' && (GetChar(m_Run+1) == 'X' || GetChar(m_Run+1) == 'x'))
            {
                m_Run += 2;
                while (HexDigits.IndexOf(GetChar(m_Run)) != -1) m_Run++;
                return;
            }
            m_Run++;
            m_TokenId = TokenKind.tkNumber;
            while (NumberStr.IndexOf(GetChar(m_Run)) != -1)
            {
                if (GetChar(m_Run) == '.' && GetChar(m_Run + 1) == '.') break;
                m_Run++;
            }

        }

        private void QuoteProc()
        {
            m_TokenId = TokenKind.tkIdentifier;
            m_Run++;
            while (!(GetChar(m_Run) == '\x00' || GetChar(m_Run) == '\x0A' || GetChar(m_Run) == '\x0D'))
            {
                if (GetChar(m_Run) == '\x22') { m_Run++; break; }
                m_Run++;
            }
        }

        private void BracketProc()
        {

            m_TokenId = TokenKind.tkIdentifier;
            m_Run++;
            while (!(GetChar(m_Run) == '\x00' || GetChar(m_Run) == '\x0A' || GetChar(m_Run) == '\x0D'))
            {
                if (GetChar(m_Run) == ']') { m_Run++; break; }
                m_Run++;
            }

        }

        private void SymbolProc()
        {
            m_Run++;
            m_TokenId = TokenKind.tkSymbol;
        }

        private void SymbolAssignProc()
        {
            m_TokenId = TokenKind.tkSymbol;
            m_Run++;
            if (GetChar(m_Run) == '=') m_Run++;
        }

        private void KeyHash(int pos)
        {
            m_StringLen = 0;
            while (Array.BinarySearch(m_IdentifiersArray, GetChar(pos)) >= 0) { m_StringLen++; pos++; }
            return;
        }
        private TokenKind IdentKind()
        {
            KeyHash(m_Run);
            return m_Tokens[m_Line.Substring(m_TokenPos, m_Run + m_StringLen - m_TokenPos)];
        }
        private void IdentProc()
        {
            m_TokenId = IdentKind();
            m_Run += m_StringLen;
            if (m_TokenId == TokenKind.tkComment)
            {
                while (!(GetChar(m_Run) == '\x00' || GetChar(m_Run) == '\x0A' || GetChar(m_Run) == '\x0D')) { m_Run++; }
            }
            else
            {
                while (IdentifierStr.IndexOf(GetChar(m_Run)) != -1) m_Run++;
            }
        }
        private void VariableProc()
        {
            if (GetChar(m_Run) == '@' && GetChar(m_Run + 1) == '@') { m_Run += 2; IdentProc(); }
            else
            {
                m_TokenId = TokenKind.tkVariable;
                int i = m_Run;
                do { i++; } while (!(IdentifierStr.IndexOf(GetChar(i)) == -1));
                m_Run = i;
            }
        }

        private void AndSymbolProc()
        {
            m_TokenId = TokenKind.tkSymbol;
            m_Run++;
            if (GetChar(m_Run) == '=' || GetChar(m_Run) == '&') m_Run++;
        }

        private void SlashProc()
        {
            m_Run++;
            switch (GetChar(m_Run))
            {
                case '*':
                    {
                        Range = SqlRange.rsComment;
                        m_TokenId = TokenKind.tkComment;
                        do
                        {
                            m_Run++;
                            if (GetChar(m_Run) == '*' && GetChar(m_Run + 1) == '/') { Range = SqlRange.rsUnknown; m_Run += 2; break; }
                        } while (!(GetChar(m_Run) == '\x00' || GetChar(m_Run) == '\x0D' || GetChar(m_Run) == '\x0A'));
                    }
                    break;
                case '=': m_Run++; m_TokenId = TokenKind.tkSymbol; break;
                default: m_TokenId = TokenKind.tkSymbol; break;

            }
        }

        private void PlusProc()
        {
            m_TokenId = TokenKind.tkSymbol;
            m_Run++;
            if (GetChar(m_Run) == '=' || GetChar(m_Run) == '=') m_Run++;

        }

        private void OrSymbolProc()
        {
            m_TokenId = TokenKind.tkSymbol;
            m_Run++;
            if (GetChar(m_Run) == '=' || GetChar(m_Run) == '|') m_Run++;
        }

        private void MinusProc()
        {
            m_Run++;
            if (GetChar(m_Run) == '-')
            {
                m_TokenId = TokenKind.tkComment;
                char c;
                do
                {
                    m_Run++;
                    c = GetChar(m_Run);
                } while (!(c == '\x00' || c == '\x0A' || c == '\x0D'));
            }
            else { m_TokenId = TokenKind.tkSymbol; }
        }

        private void LowerProc()
        {
            m_TokenId = TokenKind.tkSymbol;
            m_Run++;
            switch (GetChar(m_Run))
            {
                case '=': m_Run++; break;
                case '<': m_Run++; if (GetChar(m_Run) == '=') m_Run++; break;
            }

        }

        private void GreaterProc()
        {
            m_TokenId = TokenKind.tkSymbol;
            m_Run++;
            if (GetChar(m_Run) == '=' || GetChar(m_Run) == '>') m_Run++;
        }

        private void EqualProc()
        {
            m_TokenId = TokenKind.tkSymbol;
            m_Run++;
            if (GetChar(m_Run) == '=' || GetChar(m_Run) == '>') m_Run++;
        }

        private void Next()
        {
            m_TokenPos = m_Run;
            switch (Range)
            {
                case SqlRange.rsComment: AnsiCProc(); break;
                case SqlRange.rsString: AsciiCharProc(); break;
                default: DoProcTable(GetChar(m_Run)); break;
            }
            m_Token = m_Line.Substring(m_TokenPos, m_Run - m_TokenPos);
        }

    }
}
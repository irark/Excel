using System;
using Antlr4.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcel
{
    //class for storing cell information
    class Cell
    {
        private DataGridViewCell _parent; //cell in table
        private string _value;
        private string _formula;
        private string _name;

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == "null")
                {
                    _value = value;
                }
                else
                {
                    _value = value.Equals("0") ? "0" : "1"; //everything that isn`t zero is true
                }
            }
        }

        public string Formula
        {
            get
            {
                return _formula;
            }
            set
            {
                _formula = value;
            }
        }

        public DataGridViewCell Parent
        {
            get
            {
                return _parent;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public List<Cell> CellReferences { get; set; } 
        public Cell(DataGridViewCell parent, string name, string formula)
        {
            _parent = parent;
            _name = name;
            _formula = formula;
            _value = "0";
            CellReferences = new List<Cell>();
            CellReferences.Add(new Cell());
        }

        public Cell()
        {
            _name = "";
            Value = "0";
        }
        //calculation of the formula
        public void Evaluate()
        {
            if (_formula == "")
            {
                Value = "0";
            }
            else
            {
                CellManeger.Instance.CurrentCell = this;
                var lexer = new MyExcelLexer(new AntlrInputStream(_formula));
                lexer.RemoveErrorListeners();
                lexer.AddErrorListener(new ThrowExceptionErrorListener());
                var tokens = new CommonTokenStream(lexer);
                var parser = new MyExcelParser(tokens);
                var tree = parser.compileUnit();
                var visitor = new MyExcelVisitor();
                Value = visitor.Visit(tree).ToString();
            }

        }
    }
}

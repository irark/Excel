using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcel
{
    //class for working with cells
    class CellManeger
    {
        private DataGridView _dgvTable;
        private static CellManeger _instance;
        public Cell CurrentCell { get; set; }
        public DataGridView DgvTable
        {
            set
            {
                _dgvTable = value;
            }
        }
        public static CellManeger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CellManeger();
                }
                return _instance;
            }
        }
        private CellManeger() { }
        //by name returns information about cell(type Cell) or an indication that a cell doesn`t exist
        public Cell GetCell(string cellName)
        {
            var matches = new Regex(@"^R(?<row>\d+)C(?<col>\d+)$").Matches(cellName);
            int row = Int32.Parse(matches[0].Groups["row"].Value) - 1;
            int col = Int32.Parse(matches[0].Groups["col"].Value) - 1;
            try
            {
                return (Cell)_dgvTable[col, row].Tag;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        //chek if the cell is not reffering to itself
        public bool Loop(Cell cell, string callerName)
        {
            string cellName = cell.Name;
            if (cellName.Equals("") || !callerName.Equals(CurrentCell.Name))
            {
                return false;
            }
            if (cellName.Equals(CurrentCell.Name))
            {
                return true;
            }
            return InternalLoop(cell, callerName);
        }
        //recursive cycle check
        public bool InternalLoop(Cell cell, string callerName)
        {
            List<Cell> refs = cell.CellReferences;
            for (int i = refs.Count - 1; i >= 0; i--)
            {
                if (refs[i].Name.Equals(""))
                {
                    return false;
                }
                if (refs[i].Name.Equals(CurrentCell.Name) || Loop(refs[i], callerName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

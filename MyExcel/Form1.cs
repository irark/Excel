using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcel
{
    public partial class MyExcel : Form
    {
        private const int _maxCols = 10;
        private const int _maxRows = 10;
        private const int _rowHeaderWidth = 100;
        private const string _defaultFontName = "Arial";
        private const int _defaultFontSize = 13;
        private string _currentFilePath = "";
        private const string ERROR_LAST_ROW = "Ви не можете видалити останній рядок";
        private const string ERROR_LAST_COL = "Ви не можете видалити останній стовпець";
        private const string ERROR_DEPENDENCIES_ROW = "У таблиці наявні посилання на комірки рядка, який ви намагаєтесь видалити";
        private const string ERROR_DEPENDENCIES_COL = "У таблиці наявні посилання на комірки стовпця, який ви намагаєтесь видалити";
        private const string CAPTION_DELETE_ROW = "Видалення рядка";
        private const string CAPTION_DELETE_COL = "Видалення стовпця";
        private const string CAPTION_ERR = "Помилка";
        private const string ASK_DELETE_ROW = "Ви дійсно бажаєте видалити останній рядок?";
        private const string WARNING_EXIT = "Ви дійсно бажаєте вийти?";
        private const string CAPTION_WARNING = "Увага";
        private const string ASK_DELETE_COL = "Ви дійсно бажаєте видалити останній стовпець?";
        private const string FPATH_INFO = "C:\\Labs\\MyExcel\\INFO.txt";
        private const string CAPTION_INFO = "Довідка";

        public MyExcel()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeAllCells();
            CellManeger.Instance.DgvTable = dgvTable;
        }

        private void FillHeaders()
        {
            foreach (DataGridViewColumn col in dgvTable.Columns)
            {
                col.HeaderText = "C" + (col.Index + 1).ToString();
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                row.HeaderCell.Value = "R" + (row.Index + 1).ToString();
            }
        }

        private void InitializeDataGridView()
        {
            dgvTable.AllowUserToAddRows = false;
            dgvTable.ColumnCount = _maxCols;
            dgvTable.RowCount = _maxRows;
            FillHeaders();
            dgvTable.AutoResizeRows();
            dgvTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTable.RowHeadersWidth = _rowHeaderWidth;
        }

        private void InitializeAllCells()
        {
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                row.DefaultCellStyle.Font = new Font(_defaultFontName, _defaultFontSize, GraphicsUnit.Point);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    InitializeSingleCell(row, cell);
                }
            }
        }

        private void InitializeSingleCell(DataGridViewRow row, DataGridViewCell cell)
        {
            string cellName = "R" + (row.Index + 1).ToString() + "C" + (cell.ColumnIndex + 1).ToString();
            cell.Tag = new Cell(cell, cellName, "");
            cell.Value = "";
        }
        //updates values of all cells
        private void UpdateCellValues()
        {
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    UpdateSingleCellValue(cell);
                }
            }
        }
        private void UpdateCellValues(DataGridViewCell caller)
        {
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    Cell c = (Cell)cell.Tag;
                    if (caller != cell && c.Formula != "" && c.Formula.Contains("R"))
                    {
                        UpdateSingleCellValue(cell);
                    }
                }
            }
        }
        //updetes value of dgvCell
        private void UpdateSingleCellValue(DataGridViewCell dgvCell)
        {
            Cell cell = (Cell)dgvCell.Tag;
            dgvCell.ReadOnly = false;
            if (cell.Formula.Equals(""))
            {
                dgvCell.Value = "";
            }
            else
            {
                try
                {
                    cell.Evaluate();
                }
                catch (Exception)
                {
                    cell.Value = "null";
                }
                if (cell.Formula != "")
                {
                    dgvCell.Value = cell.Value;
                }
                else
                {
                    dgvCell.Value = "";
                }
            }
            dgvCell.ReadOnly = true;
        }
        //preparing the cell for editing
        private void dgvTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Cell cell = (Cell)dgvTable[e.ColumnIndex, e.RowIndex].Tag;
            CellManeger.Instance.CurrentCell = cell;
            DataGridViewCell dgvCell = cell.Parent;
            dgvCell.Value = "";
        }
        //changes the list of links in this cell to others
        private void ClearRemovedReferences(Cell cell)
        {
            List<Cell> removedCells = new List<Cell>();
            foreach (Cell refCell in cell.CellReferences)
            {
                if (!cell.Formula.Contains(refCell.Name))
                {
                    removedCells.Add(refCell);
                }
            }
            foreach (Cell refCell in removedCells)
            {
                cell.CellReferences.Remove(refCell);
            }
        }
        //calculation of cell value
        private void ResolveCellFormula(Cell cell, DataGridViewCell dgvCell)
        {
            try
            {
                cell.Evaluate();
            }
            catch (Exception)
            {
                cell.Value = "null";
            }
            if (cell.Value == "null")
            {
                MessageBox.Show("Помилка у формулі!", CAPTION_ERR, MessageBoxButtons.OK);
            }
            if (cell.Formula != "")
            {
                dgvCell.Value = cell.Value;
            }
            else
            {
                dgvCell.Value = "";
            }
            UpdateCellValues(dgvCell);
        }
        //editing
        private void dgvTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Cell cell = (Cell)dgvTable[e.ColumnIndex, e.RowIndex].Tag;
            DataGridViewCell dgvCell = cell.Parent;
            cell.Formula = tbFormula.Text;
            if (tbFormula.Text == null)
            {
                cell.Formula = "";
                cell.Value = "0";
                dgvCell.Value = "";
            }
            ClearRemovedReferences(cell);
            ResolveCellFormula(cell, dgvCell);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedCells.Count == 0 || dgvTable.SelectedCells.Count > 1)
            {
                tbFormula.Text = "";
            }
            else
            {
                Cell cell = (Cell)(dgvTable.SelectedCells[0]).Tag;

                cell.Formula = tbFormula.Text;
                DataGridViewCell dgvCell = cell.Parent;
                dgvCell.ReadOnly = false;
                dgvTable.BeginEdit(true);
                dgvTable.EndEdit();
                dgvCell.ReadOnly = true;
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cell cell = (Cell)(dgvTable.SelectedCells[0]).Tag;
            tbFormula.Text = cell.Formula;
            dgvTable.SelectedCells[0].ReadOnly = true;
        }

        private void SaveDataGridView(string filePath)
        {
            _currentFilePath = filePath;
            dgvTable.EndEdit();
            DataTable table = new DataTable("table");
            foreach (DataGridViewColumn dgvColumn in dgvTable.Columns)
            {
                table.Columns.Add(dgvColumn.Index.ToString());
            }
            foreach (DataGridViewRow dgvRow in dgvTable.Rows)
            {
                DataRow dataRow = table.NewRow();
                foreach (DataColumn col in table.Columns)
                {
                    Cell cell = (Cell)dgvRow.Cells[Int32.Parse(col.ColumnName)].Tag;
                    dataRow[col.ColumnName] = cell.Formula;
                }
                table.Rows.Add(dataRow);
            }
            table.WriteXml(filePath);
        }

        private void LoadDataGridView(string filePath)
        {
            _currentFilePath = filePath;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(filePath);
            DataTable table = dataSet.Tables[0];
            dgvTable.ColumnCount = table.Columns.Count;
            dgvTable.RowCount = table.Rows.Count;
            FillHeaders();
            foreach (DataGridViewRow dgvRow in dgvTable.Rows)
            {
                foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                {
                    string cellName = "R" + (dgvRow.Index + 1).ToString() + "C" + (dgvCell.ColumnIndex + 1).ToString();
                    string formula = table.Rows[dgvCell.RowIndex][dgvCell.ColumnIndex].ToString();
                    dgvCell.Tag = new Cell(dgvCell, cellName, formula);
                }
            }
            UpdateCellValues();
        }

        private void tlmOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CellManeger.Instance.CurrentCell = new Cell();
                LoadDataGridView(openFileDialog.FileName);
            }
        }

        private void tlmSave_Click(object sender, EventArgs e)
        {
            if (!_currentFilePath.Equals(""))
            {
                SaveDataGridView(_currentFilePath);
            }
            else if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDataGridView(saveFileDialog.FileName);
            }
        }

        private void AddRow()
        {
            dgvTable.Rows.Add(new DataGridViewRow());
            FillHeaders();
            DataGridViewRow addedRow = dgvTable.Rows[dgvTable.RowCount - 1];
            addedRow.DefaultCellStyle.Font = new Font(_defaultFontName, _defaultFontSize, GraphicsUnit.Point);
            foreach (DataGridViewCell cell in addedRow.Cells)
            {
                InitializeSingleCell(addedRow, cell);
            }
        }

        private void AddColumn()
        {
            dgvTable.Columns.Add(new DataGridViewColumn(dgvTable.Rows[0].Cells[0]));
            FillHeaders();
            foreach (DataGridViewRow dgvRow in dgvTable.Rows)
            {
                InitializeSingleCell(dgvRow, dgvRow.Cells[dgvTable.ColumnCount - 1]);
            }
        }

        private void DeleteRow()
        {
            DialogResult result = MessageBox.Show(ASK_DELETE_ROW, CAPTION_DELETE_ROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (dgvTable.RowCount == 1)
                {
                    MessageBox.Show(ERROR_LAST_ROW, CAPTION_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DeletedRowHasDependencies())
                {
                    MessageBox.Show(ERROR_DEPENDENCIES_ROW, CAPTION_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int lastRowInd = dgvTable.RowCount - 1;
                dgvTable.Rows.RemoveAt(lastRowInd);
            }
        }

        private bool DeletedRowHasDependencies()
        {
            List<string> deletedNames = new List<string>();
            int lastInd = dgvTable.RowCount - 1;
            foreach (DataGridViewCell dgvCell in dgvTable.Rows[lastInd].Cells)
            {
                Cell cell = (Cell)dgvCell.Tag;
                deletedNames.Add(cell.Name);
            }
            return FindDeletedRowDependenciesInTable(deletedNames, lastInd);
        }

        private bool FindDeletedRowDependenciesInTable(List<string> deletedNames, int lastInd)
        {
            for (int i = 0; i < lastInd; i++)
            {
                foreach (DataGridViewCell dgvCell in dgvTable.Rows[i].Cells)
                {
                    Cell cell = (Cell)dgvCell.Tag;
                    List<Cell> refs = cell.CellReferences;
                    for (int j = refs.Count - 1; j >= 0; j--)
                    {
                        if (deletedNames.Contains(refs[j].Name))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void DeleteColumn()
        {
            DialogResult result = MessageBox.Show(ASK_DELETE_COL, CAPTION_DELETE_COL, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (dgvTable.ColumnCount == 1)
                {
                    MessageBox.Show(ERROR_LAST_COL, CAPTION_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DeletedColHasDependencies())
                {
                    MessageBox.Show(ERROR_DEPENDENCIES_COL, CAPTION_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int lastColInd = dgvTable.ColumnCount - 1;
                dgvTable.Columns.RemoveAt(lastColInd);
            }
        }

        private bool DeletedColHasDependencies()
        {
            List<string> deletedNames = new List<string>();
            int lastInd = dgvTable.ColumnCount - 1;
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                Cell cell = (Cell)row.Cells[lastInd].Tag;
                deletedNames.Add(cell.Name);
            }
            return FindDeletedColDependenciesInTable(deletedNames, lastInd);
        }

        private bool FindDeletedColDependenciesInTable(List<string> deletedNames, int lastInd)
        {
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                for (int i = 0; i < lastInd; i++)
                {
                    Cell cell = (Cell)row.Cells[i].Tag;
                    List<Cell> refs = cell.CellReferences;
                    for (int j = refs.Count - 1; j >= 0; j--)
                    {
                        if (deletedNames.Contains(refs[j].Name))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void tlmAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void tlmAddColumn_Click(object sender, EventArgs e)
        {
            AddColumn();
        }

        private void tlmDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void tlmDeleteColumn_Click(object sender, EventArgs e)
        {
            DeleteColumn();
        }

        private void MyExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(WARNING_EXIT, CAPTION_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            return;
        }

        private void tsmInfo_Click(object sender, EventArgs e)
        {
            string info = System.IO.File.ReadAllText(FPATH_INFO);
            MessageBox.Show(info, CAPTION_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

using System;
using Antlr4;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcel
{
    class MyExcelVisitor : MyExcelBaseVisitor<string>
    {
        public override string VisitCompileUnit(MyExcelParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }
        public override string VisitNumberExpr(MyExcelParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result.ToString();
        }
        //NotExpr
        public override string VisitNotExpr(MyExcelParser.NotExprContext context)
        {
            var right = WalkLeft(context);

            if (right == "null")
            {
                return "null";
            }
            Debug.WriteLine("!{0}", right);
            if (double.Parse(right) == 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        //IdentifierExpr
        public override string VisitIdentifierExpr(MyExcelParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            Cell caller = CellManeger.Instance.CurrentCell;
            Cell cell = CellManeger.Instance.GetCell(result);
            if (cell == null)
            {
                return "null";
            }
            if (CellManeger.Instance.Loop(cell, caller.Name))
            {
                return "null";
            }

            if (!caller.CellReferences.Contains(cell))
            {
                caller.CellReferences.Add(cell);
            }
            cell.Evaluate();
            return cell.Value;
        }
        //ParenthesizedExpr
        public override string VisitParenthesizedExpr(MyExcelParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }
      
        public override string VisitAdditiveExpr(MyExcelParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if(left == "")
            {
                left = "0";
            }
            if (right == "null" || left == "null")
            {
                return "null";
            }
            if (context.operatorToken.Type == MyExcelLexer.ADD)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return (double.Parse(left) + double.Parse(right)).ToString();
            }
            else
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return (double.Parse(left) - double.Parse(right)).ToString();
            }
        }
        public override string VisitMultiplicativeExpr(MyExcelParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (right == "null" || left == "null")
            {
                return "null";
            }
            if (context.operatorToken.Type == MyExcelLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return (double.Parse(left) * double.Parse(right)).ToString();
            }
            else if (context.operatorToken.Type == MyExcelLexer.DIVIDE)
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return (double.Parse(left) / double.Parse(right)).ToString();
            }
            else if (context.operatorToken.Type == MyExcelLexer.DIV)
            {
                Debug.WriteLine("{0} : {1}", left, right);
                return ((int)(double.Parse(left) / double.Parse(right))).ToString();
            }
            else
            {
                Debug.WriteLine("{0} % {1}", left, right);
                return (double.Parse(left) % double.Parse(right)).ToString();
            }
        }

        //ComperativeExpr
        public override string VisitComperativeExpr(MyExcelParser.ComperativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (right == "null" || left == "null")
            {
                return "null";
            }
            if (context.operatorToken.Type == MyExcelLexer.OVER)
            {
                Debug.WriteLine("{0} > {1}", left, right);
                if (double.Parse(left) > double.Parse(right))
                    return "1";
                else
                    return "0";
            }
            else if (context.operatorToken.Type == MyExcelLexer.LESS)
            {
                Debug.WriteLine("{0} < {1}", left, right);
                if (double.Parse(left) < double.Parse(right))
                    return "1";
                else
                    return "0";
            }
            else
            {
                Debug.WriteLine("{0} = {1}", left, right);
                if (left == right)
                    return "1";
                else
                    return "0";
            }
        }
        private string WalkLeft(MyExcelParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<MyExcelParser.ExpressionContext>(0));
        }
        private string WalkRight(MyExcelParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<MyExcelParser.ExpressionContext>(1));
        }
    }
}

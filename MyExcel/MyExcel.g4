grammar MyExcel;
/*
*Parser Rules
*/
compileUnit : expression EOF;

expression:
	LPAREN expression RPAREN #ParenthesizedExpr
	//|operatorToken=(MINUS|PLUS) expression #UnarExpr
	|NOT expression #NotExpr
	|expression operatorToken=(MULTIPLY|DIVIDE|DIV|MOD)expression #MultiplicativeExpr
	|expression operatorToken=(ADD|SUBTRACT) expression #AdditiveExpr
	|expression operatorToken=(OVER|LESS|EQUAL) expression #ComperativeExpr
	|NUMBER #NumberExpr
	|IDENTIFIER #IdentifierExpr
	;
/*
*Lexer Rules
*/
NUMBER: INT('.'INT)?;
IDENTIFIER: ROW+COLUMN;
COLUMN: 'C'+('0'..'9')+;
ROW: 'R'+('0'..'9')+;

INT: ('0'..'9')+;
//MINUS: '-';
//PLUS: '+';
NOT: '!';
MULTIPLY: '*';
DIVIDE: '/';
DIV: ':';
MOD: '%';
SUBTRACT: '-';
ADD: '+';
LESS: '<';
OVER: '>';
EQUAL: '=';
LPAREN:'(';
RPAREN: ')';

WS: [\t\r\n' '] -> channel(HIDDEN);
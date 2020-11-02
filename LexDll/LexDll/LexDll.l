/* Mohammad Ishrak Abedin, ID# 160041051, Compiler Design Lab, CSE 4802 */
%{

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>

#define YY_NO_UNISTD_H
#include <io.h>

#define isatty _isatty
#define fileno _fileno

typedef void (__stdcall* callbackptr)(int, char*);
callbackptr callback;
%}

%%
[0-9]+ {
	callback(0, yytext);
}
[a-zA-Z]+ {
	callback(1, yytext);
}
. ;
%%

int yywrap(void)
{
	return 1;
}


extern _declspec(dllexport) int _stdcall mainloop(callbackptr cbp)
{
	callback = cbp;
	yylex();
	return 0;
}
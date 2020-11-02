from lexer import execute_main_loop
import ctypes

@ctypes.CFUNCTYPE(None, ctypes.c_int, ctypes.c_char_p)
def lex_handler(case, yytext):
    yytext = yytext.decode("utf-8")
    if(case == 0):
        print(f"Detected Text, Code {yytext}")
    elif(case == 1):
        print(f"Detected Number, Code {yytext}")
    else:
        print("Detected Unknown Charater(s)")

def main():
    ret_val = execute_main_loop(lex_handler)
    print(f"Lex Loop Returned {ret_val}")
    return 0

main()
import ctypes

lexdll = ctypes.windll.LoadLibrary("./LexDll.dll")

lex_main_loop = lexdll.mainloop
#lex_main_loop.argtypes = [ctypes.CFUNCTYPE(None, ctypes.c_int, ctypes.c_char_p)]
#lex_main_loop.restype = ctypes.c_int 

def execute_main_loop(func):
    rtrn = lex_main_loop(func)
    return rtrn

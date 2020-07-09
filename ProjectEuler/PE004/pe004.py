def main():
    max_rst = 0
    for x in range(100, 1000):
        for y in range(100,1000):
            chk_val = x * y
            if palindromic(chk_val) and chk_val > max_rst:
                max_rst = chk_val
    print(max_rst)
                
def palindromic(arg):
    str_arg = str(arg)
    rst = True if str_arg == str_arg[::-1] else False
    return rst
    
    
if __name__=="__main__":
    main()
    
# Answer: 906609
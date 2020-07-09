def main():
    print(sumDigits(2**1000))
    
    
def sumDigits(n):
    """return sum of all digits in n"""
    rst = 0
    for s in str(int(n)):
        rst += int(s)
    return rst
    
    
if __name__=="__main__":
    main()
    
# 1366
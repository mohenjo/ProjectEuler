def isPalindromic(string):
    '''return True if string is palidromic'''
    rst = True if string == string[::-1] else False
    return rst
    
    
def main():
    summation = 0
    for i in range(1, 10**6):
        chk10 = str(i)
        chk2 = bin(i)[2:]
        if isPalindromic(chk10) and isPalindromic(chk2):
            summation += i
    print(summation)
    
if __name__=="__main__":
    main()
    
# 872187
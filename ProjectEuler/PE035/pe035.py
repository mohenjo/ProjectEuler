def getCircular(n):
    ## 숫자 n의 circular 리스트 반환
    rst = list()
    inp = str(n)
    for idx in range(len(inp)):
        rst.append(int(inp[idx:] + inp[:idx]))
    return rst

    
def isPrime(n):
    """n이 소수인지 판단. True for yes"""
    # rst = all([(n % i) for i in range(2, int(n**0.5)+1)]) and n > 1
    if n < 2:
        return False
    chk = True
    for i in range(2, int(n**0.5)+1):
        if n % i == 0:
            chk = False
            break
    return chk
    

def chkPrime(n):
    ##n 및 이의 circular list 값이 모두 소수인지 여부 반환
    chk = True
    for value in getCircular(n):
        if not isPrime(value):
            chk = False
            break
    return chk
    
def main():
    rst = list()
    for i in range(2, 10**6):
        print("{} of {} processing.".format(i, 10**6), end="\r")
        if isPrime(i):
            if chkPrime(i):
                rst.append(i)
    print()
    print(len(rst))
    
if __name__=="__main__":
    main()
    
    
# 55    
def isPrime(n):
    """n이 소수인지 판단. True for yes"""
    if n < 2:
        return False
    chk = True
    for i in range(2, int(n**0.5)+1):
        if n % i == 0:
            chk = False
            break
    return chk
    

def eq(a, b, n):
    """Euler's quadratic formula"""
    ## : coefficient: a, b int
    ## : n int | n >= 0
    rst = n**2 + a*n + b
    return rst
    

def primeLength(a, b):
    ### 주어진 계수 a, b에 대해 Euler's quadratic formula가 연속적으로 소수를
    ### 생성하는 n의 범위(길이)를 반환
    ### : n int >= 0
    
    # case A: 최초 소수 발생 포인트 체크
    # n = 0
    # chk = False
    # while not chk:
        # eq_chk = isPrime(eq(a, b, n))
        # if eq_chk:
            # chk = True
            # startFrom = n
            # break
        # else:
            # n += 1
            
    ## 최초 소수 발생 포인트가 0이라고 가정할 경우
    n = 0
    startFrom = n
    chk = True
    ## 소수 중단 포인트 체크
    while chk:
        eq_chk = isPrime(eq(a, b, n))
        if not eq_chk:
            chk = False
            endBelow = n
            break
        else:
            n += 1
    primeLength = endBelow - startFrom    
    return primeLength


def main():
    maxLen = 0
    chk_a = chk_b = None
    for a in range(-999, 1000):
        print("processing {0} of [{1}, {2}].".format(a, -999, 999), end="\r")
        for b in range(-1000, 1001):
            rst = primeLength(a, b)
            if rst >= maxLen:
                maxLen = rst
                chk_a = a
                chk_b = b
    print()
    print(chk_a * chk_b)
    
    
if __name__=="__main__":
    main()
    
# -59231
        
    
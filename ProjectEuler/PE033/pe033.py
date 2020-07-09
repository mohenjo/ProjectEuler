"""
Equations:
Eq(1): (10a + b) / (10b + c) < 1
Eq(2): (10a + b ) / (10b + c) = a/c
Where,
: 1 <= a, b, c int <= 9 
: a != b, a != c

from Eq(1), 9b > 10a - c
from Eq(2), b = 9ac / (10a - c)
"""

def getProduct(aList):
    ## [(a1, b1, c1), (a2, b2, c2), ...]로 구성된 리스트를 인자로 받아서
    ## (10a + b ) / (10b + c)들의 곱 분수(numerator, denominator)를 반환
    numerator = 1
    denominator = 1
    for value in aList:
        numerator *= (value[0]*10 + value[1])
        denominator *= (value[1]*10 + value[2])
    return (numerator, denominator)

    
def divisors(n):
    """n의 약수 리스트 반환"""
    lst = list()
    for i in range(1, int(n**0.5)+1):
        if n % i ==0:
            lst += [i, n//i]
    lst = list(set(lst))
    lst.sort()
    return lst

def main():
    ## 조건을 만족하는 a, b, c 케이스 추출
    rst = list()
    for a in range(1, 10):
        for c in range(1, 10):
            if a == c: continue
            b = 9*a*c / (10*a - c)
            if a == b or b != int(b) or b not in range(1, 10): 
                continue
            else:
                b = int(b)
            if 9*b > (10*a - c):
                rst.append((a, b, c))
    ## 조건을 만족하는 분수들의 곱(분자, 분모) 반환
    result = getProduct(rst)
    ## 분자, 분모의 최대 공약수 반환
    comdiv = max(set(divisors(result[0])) & set(divisors(result[1])))
    
    rst = int(result[1]/comdiv) # 약분된 분모
    print(rst)
    
    
if __name__=="__main__":
    main()
    
# 100
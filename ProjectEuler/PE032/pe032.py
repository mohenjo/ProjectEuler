"""자리수 구분을 위한 검토
조건. 두 수의 곱 및 결과가 pandigital이어야 함.
: 총 9개의 수가 한 번씩만 등장(총 9자리)

체크 - 2자리 * 2 자리
:최소 14 * 23 = 322 -> 7자리 (X)
:최대 98 * 86 = 8342 -> 8자리 (X)

체크 - 3자리 * 3자리
: 최소 146 * 235 = 34310 -> 11 자리 (X)

즉, 3자리 수 * 2자리 수 = 4 자리 수의 관계가 나와야 함
추가로 1자리 수 * 4자리 수 = 4 자리 수의 관계도 고려
"""


def isPandigital(s):
    ## 주어진 문자열 s(숫자로 구성) pandigital일 경우 True 반환
    ## pandigital: 중복되는 숫자 없이 구성될 경우 (1..9)
    if "0" in s: return False
    rst = True if len(s) == len(set(s)) else False
    return rst
    

def main():
    rst_pool = list()
    ## 3자리 * 2자리
    for d3 in range(100, 1000): # 3자리 수
        d3str = str(d3)
        if not isPandigital(d3str): continue
        for d2 in range(10, 100): # 2자리 수
            d2str = str(d2)
            if not isPandigital(d2str): continue
            product = d3 * d2
            productstr = str(product)
            allstr = d3str + d2str + productstr
            if len(allstr) == 9 and isPandigital(allstr):
                rst_pool.append(product)
    ## 4자리 * 1 자리
    for d4 in range(1000, 10000): # 4자리 수
        d4str = str(d4)
        if not isPandigital(d4str): continue
        for d1 in range(1, 10): # 1자리 수
            d1str = str(d1)
            product = d4 * d1
            productstr = str(product)
            allstr = d4str + d1str + productstr
            if len(allstr) == 9 and isPandigital(allstr):
                rst_pool.append(product)
    print(sum(set(rst_pool)))
    
    
if __name__=="__main__":
    main()
    
# 45228
    
    

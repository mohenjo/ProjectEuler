'''
9! = 362880
각 자리수 별 도출 가능 최대 값 계산
5자리 99999 => 9! * 5 = 1,814,400 : 최대 7자리
6자리 999999 => 9! * 6 = 2,177,280 : 최대 7자리 
7자리 9999999 => 9! * 7 = 2,540,160 : 최대 7자리
8자리 99999999 => 9! * 8 = 2,903,040 : 최대 7자리
...
즉, 8자리 수로는 최대값이라 하더라도 8자리 결과를 만들어 내지 못함.
범위는 7자리, 계산 최대값까지 [3..2540160]
'''
maxVal = 2540160

# factorial = (1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880)
def factorial(n):
    rst = 1 if n==0 else n * factorial(n-1)
    return rst
    
    
def sum_factorial(n):
    ## 숫자 n의 각 자리 수의 factorial 값의 합을 반환
    rst = sum((factorial(int(s)) for s in str(n)))
    return rst
    
    
def main():
    rst = list()
    for i in range(3, maxVal+1):
        print("{} of {} processing.".format(i, maxVal), end="\r")
        if i == sum_factorial(i):
            rst.append(i)
    print()
    print(sum(rst))
    

if __name__=="__main__":
    main()
    
# 40730
def chkMaxDigits(): # 프로그램 처리에 포함되지 않음. 가정 사항 체크용 루틴
    for i in range(17):
        print(9**5 * i)
    # 17자리 숫자까지 sum(각자리 최고 수(9)**5의 값)이 6자리를 넘지 않음.
    # <-- 9**5 + 9 **5  + ...
    # 즉, 범위 가정: range(2, 10^6)
    

def isOk(n):
    ## n의 각 자리수의 5승 합이 n과 같을 경우 True 반환
    # n의 자리 수 범위는 [2, N] -> chkMaxDigits의 검토 결과 참조
    nStrings = str(n)
    digitSum = 0
    for nString in nStrings:
        digitSum += int(nString)**5
    return n == digitSum
    
def main():
    maxNum = 10**6 # chkMaxDigits 범위 
    pool = list()
    for i in range(2, maxNum):
        if isOk(i):
            pool.append(i)
    print(sum(pool))
    
    
if __name__=="__main__":
    main()
    
# 443839
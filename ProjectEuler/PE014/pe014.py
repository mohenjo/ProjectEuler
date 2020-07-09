def main():
    maxVal = 0
    maxLen = 0
    upTo = 1000000
    for i in range(1, upTo+1):
        ## 연산 시간이 길므로 계산 과정 화면에 표시
        print("Processing.. {0:5.1f}% completed.".format(i/(upTo+1)*100), end="\r")
        curLen = lenCollatz(i)
        if curLen > maxLen:
            maxVal = i
            maxLen = curLen
    print()
    print("{} has the longest Collatz chain, {}".format(maxVal, maxLen))
        

def lenCollatz(n):
    """숫자 n에 대한 Collatz 시퀀스 길이 반환"""
    ## n -> n/2 if n is even else 3n+1
    ## 예. 13 > 40 > 20 > 10 > 5 > 16 > 8 > 4 > 2 > 1 : return 10
    curVal = n
    length = 1
    while curVal != 1:
        curVal = curVal/2 if curVal % 2 == 0 else 3*curVal + 1
        length += 1
    return length
        

if __name__=="__main__":
    main()
    
# 83799
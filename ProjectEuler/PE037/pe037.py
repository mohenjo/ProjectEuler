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
    
    
def generatePrimeNumbers():
    """소수 제너레이터"""
    current = 2 # 문제에서 2, 3, 5, 7은 고려하지 않음(not truncatable)
    while True:
        if isPrime(current):
            yield current
        current += 1

        
def retTruncated(n):
    """주어진 숫자 n에 대해 left / right truncated 숫자 리스트 반환"""
    sVal = str(n)
    sLen = len(sVal)
    lst = [int(sVal)]
    for i in range(1,sLen):
        lst.append(int(sVal[i:sLen]))
        lst.append(int(sVal[:-i]))
    return lst

    
def isTruncatablePrime(n):
    """입력된 n의 retTruncated 리스트 내의 모든 숫자가 prime인지 판단"""
    lstOfNumbers = retTruncated(n)
    if lstOfNumbers[0] <= 7: # 2, 3, 5, 7은 not truncatable prime
        return False
    chk = all([isPrime(number) for number in lstOfNumbers])
    return chk

    
def main():
    count = 0
    rst_lst = list()
    gen = generatePrimeNumbers()
    
    while count < 11:
        next_prime = next(gen)
        chk = isTruncatablePrime(next_prime)
        if chk:
            count += 1
            rst_lst.append(next_prime)
    print(sum(rst_lst))
    
    
if __name__=="__main__":
    main()
    
# 748317
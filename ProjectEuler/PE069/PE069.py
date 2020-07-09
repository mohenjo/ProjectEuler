from functools import reduce

# ------ brute force 방식 (채택 안함) ------
def get_nperphi(num):
    tgtnum = num
    curnum = 2
    primes = set()
    while tgtnum != 1:
        while tgtnum % curnum == 0:
            primes.add(curnum)
            tgtnum /= curnum
        curnum +=1
    return num / len([n for n in range(1, num) if all((n % p != 0 for p in primes))])

def PE069_bf():
    max_n = 0
    max_nperphi = 0
    for n in range(2,1000_001):
        print(n, end='\r')
        cmpval = get_nperphi(n)
        if cmpval > max_nperphi: 
            max_n = n
            max_nperphi = cmpval
    print()
    print(max_n)

# ------
def PE069_solved():
    # n / phi(n)의 최대값을 찾는 문제
    # phi(n)은 n보다 작으면서 n과 서로소인 숫자의 개수를 의미함.
    # 즉, phi(n) = n - n과 공약수를 갖는 수의 개수
    #
    # n (<1M)은 클수록, phi(n)은 작을 수록 구하는 값에 가까워짐.
    # phi(n)가 작다는 의미는 n이하의 수 중 n과 공약수를 갖는 수가 많다는 의미임.
    # "공약수가 많으려면 공약수를 이루는 소수의 개수가 많아야 함"
    # 즉, n = 2 * 3 * 5 * ...  방식으로 소수(prime number)의 연속 곱으로 이루어진 경우가 해당됨 (1)
    #
    # n / phi(n) 가 최대가 되는 수는 소수의 연속곱으로 계산되는 수 중 1M 이하에서 최대값인 수임
    primes = [2]
    curnum = 2
    result = 0
    while curnum < 100:
        if all(map(lambda p: curnum % p != 0, primes)):
            primes.append(curnum)
        curnum += 1
        mul = reduce(lambda x, y: x * y, primes)
        if mul > 1_000_000:
            break
        result = mul
    print(result)  # 510510

if __name__ == "__main__":
    #PE069_bf() # brute force 방식은 연산에 많은 시간이 소요됨
    PE069_solved()

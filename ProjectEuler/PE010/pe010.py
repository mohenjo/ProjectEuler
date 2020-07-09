def IsPrime(n):
    """n이 소수인지 판단. True for yes"""
    # rst = all([(n % i) for i in range(2, int(n**0.5)+1)]) and n > 1
    if n < 2:
        return False
    chk = True
    for i in range(2, int(n ** 0.5) + 1):
        if n % i == 0:
            chk = False
            break
    return chk


def GeneratePrimeNumbers():
    """소수 제너레이터"""
    current = 2
    while True:
        if IsPrime(current):
            yield current
        current += 1


def main():
    gen_pn = GeneratePrimeNumbers()
    cur_val = next(gen_pn)
    sum = 0
    while cur_val <= 2e6:
        sum += cur_val
        # 계산 시간이 오래 걸리므로 중간 과정 화면에 표시
        print("Last generated prime number: {}".format(cur_val), end="\r")
        cur_val = next(gen_pn)
    print()
    print(sum)


if __name__ == "__main__":
    main()

# 142913828922

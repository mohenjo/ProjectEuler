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
    rst = GeneratePrimeNumbers()
    for i in range(10001):
        gen_val = next(rst)
    print(gen_val)


if __name__ == "__main__":
    main()

# Answer: 104743

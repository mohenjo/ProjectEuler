def GenFibo():
    """피보나치 수열 생성"""
    a = 1
    b = 2
    while True:
        yield a
        c = a + b
        a = b
        b = c


def main():
    fibo = GenFibo()
    chk_val = next(fibo)
    sum = 0
    while chk_val <= 4e6:
        if chk_val % 2 == 0:
            sum += chk_val
        chk_val = next(fibo)
    print(sum)


if __name__ == "__main__":
    main()

# Answer: 4613732

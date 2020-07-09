def PrimeFactors(n):
    """n의 소수 리스트 반환"""
    prime_col = list()
    target = n
    current = 2
    while current <= target:
        if target % current == 0:
            prime_col.append(current)
            target = target / current
        current += 1
    return prime_col


def main():
    lst = PrimeFactors(600851475143)
    print(max(lst))


if __name__ == "__main__":
    main()

# Answer: 6857

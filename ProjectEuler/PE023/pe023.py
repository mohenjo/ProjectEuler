def Divisors(n):
    """n의 약수 리스트 반환"""
    lst = list()
    for i in range(1, int(n ** 0.5) + 1):
        if n % i == 0:
            lst += [i, n // i]
    lst = list(set(lst))
    lst.sort()
    return lst


def main():
    abdnt_lst = list()
    for i in range(1, 28124):
        if i < sum(Divisors(i)) - i:
            abdnt_lst.append(i)

    pool = [i for i in range(28124)]
    for i in abdnt_lst:
        print("{0:6.2f}% processing.".format(i / max(abdnt_lst) * 100), end="\r")
        for j in abdnt_lst:
            if i + j <= 28123:
                pool[i + j] = 0
    print()
    print(sum(pool))


if __name__ == "__main__":
    main()

# 4179871

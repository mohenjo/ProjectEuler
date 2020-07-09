def Divisors(n):
    """n의 약수 리스트 반환"""
    lst = list()
    for i in range(1, int(n ** 0.5) + 1):
        if n % i == 0:
            lst += [i, n // i]
    lst = list(set(lst))
    lst.sort()
    return lst


def amicable(a):
    """친화수(amicable number) 반환"""
    ## a의 약수의 합을 d(a)이라고 하면, d(a) = b and d(b) = a 인 관계 (a != b)
    b = sum(Divisors(a)) - a  # 자기 자신 제외
    db = sum(Divisors(b)) - b
    if a == db and a != b:
        return b
    else:
        return 0


def main():
    span = range(1, 10001)
    lst = [0 for i in span]
    for i in span:
        cal = amicable(i)
        if cal != 0 and (cal in span):
            lst[i] = i
            lst[cal] = cal
    rst = sum(lst)
    print(rst)


if __name__ == "__main__":
    main()

# 31626

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
    genNum = genTriangleNumbers()
    while True:
        curVal = next(genNum)
        curLen = len(Divisors(curVal))
        # 연산 시간이 오래 걸리므로 중간 과정 출력
        print("Processing triangle number: {} -> get {} divisors".format(curVal, curLen), end="\r")
        if curLen > 500:
            print()
            print(curVal)
            break


def genTriangleNumbers():
    cur = 1
    gen = 0
    while True:
        gen += cur
        yield gen
        cur += 1


if __name__ == "__main__":
    main()

# 76576500

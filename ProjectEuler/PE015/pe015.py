"""경로 찾는 경우의 수
dx, dy 크기의 셀이 x개, y개로 이루어진 그리드에서 목적지까지의 경우의 수는
(단 이동은 dx, dy의 양의 방향으로만 가능)
dx * x개 와 dx * y개를 일렬로 배열하는 방법의 수와 같다.
즉, (x + y)! / (x! * y!)"""


def fn(n):  # factorial
    rst = 1 if n == 0 else n * fn(n - 1)
    return rst


def main():
    x = 20
    y = 20
    rst = int(fn(x + y) / (fn(x) * fn(y)))
    print(rst)


if __name__ == "__main__":
    main()

# 137846528820

# 양의 정수 x에 대해,
# 문제의 조건을 만족하기 위해서는 x**2 이 19자리의 숫자여야 한다. 즉,
# 10**18 <= x**2 < 10**19
# 10**9 <= x < 10**9.5 (=3,162,277,660) --- (1)
# 또한 첫자리가 1이므로, x의 첫 숫자는 1 또는 4이어야 하는데,
# (1)에 의해 x의 첫 숫자는 1이어야 한다 --- (2)
# 또한 마지막 자리는 0이어야 한다. --- (3)
# 즉,
# 10**9 <= x < 1_999_999_990, x는 10의 배수


def is_match(n):
    s = str(n**2)
    return all(int(s[i*2]) == i+1 for i in range(9))


def main():
    for n in range(10**9, 1_999_999_990+1, 10):
        if is_match(n):
            print(n)  # 1389019170
            break


if __name__ == "__main__":
    main()
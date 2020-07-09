def Factorial(n):
    rst = 1 if n == 0 else n * Factorial(n - 1)
    return rst


def sumDigits(number):
    string = str(number)
    rst = 0
    for s in string:
        rst += int(s)
    return rst


def main():
    number = 100
    print(sumDigits(Factorial(number)))


if __name__ == "__main__":
    main()

# 648

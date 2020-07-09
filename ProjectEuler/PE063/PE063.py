import math


def is_ndigit(x, n):
    return int(math.log10(x**n))+1 == n


def main():
    count = 0
    for x in range(1, 10):
        for n in range(1, 21+1):
            if is_ndigit(x, n):
                count += 1
    print(count)


if __name__ == "__main__":
    main()

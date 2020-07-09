def main():
    # non-Mersenne prime: 28433 * (2 ** 7830457) + 1
    last10 = 1
    for i in range(7830457):
        last10 *= 2
        if len(str(last10)) > 10:
            last10 = int(str(last10)[-10:])
    last10 = 28433 * last10 + 1
    print(str(last10)[-10:])  # 8739992577


if __name__ == "__main__":
    main()

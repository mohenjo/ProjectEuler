def main():
    max_val = 1_000_000
    criteria_numerator = 3
    criteria_denominator = 7
    for d in range(max_val, 0, -1):
        if d % criteria_denominator == 0:
            multiply = d // criteria_denominator
            criteria_numerator *= multiply
            criteria_denominator *= multiply
            break
    print(criteria_numerator - 1)  # 428570


if __name__ == "__main__":
    main()

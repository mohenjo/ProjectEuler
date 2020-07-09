def isprime(anum):
    if anum == 1:
        return False
    for n in range(2, int(anum**0.5)+1):
        if anum % n == 0:
            return False
    return True


def main():
    side_length = 1
    count_diagonal = 1
    count_prime = 0
    criteria = 0.1
    while (True):
        side_length += 2
        new_diagonal_set = [side_length**2 - (side_length-1)*3,
                            side_length**2 - (side_length-1)*2,
                            side_length**2 - (side_length-1),
                            side_length**2]
        count_diagonal += 4
        count_prime += len([n for n in new_diagonal_set if isprime(n)])
        print(
            f"processing side length {side_length}...{count_prime / count_diagonal*100: .2f}%", end="\r")
        if count_prime / count_diagonal <= criteria:
            print()
            print(side_length)
            break


if __name__ == "__main__":
    main()  # 26241

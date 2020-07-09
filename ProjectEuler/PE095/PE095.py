def PE095():
    longest_length = 0
    minimum_value = 0
    for n in range(1, 1_000_000 + 1):
        print(n, end = "\r")
        rst = get_amicable_chain_len(n)
        if rst[0] == True:
            if rst[1] > longest_length:
                longest_length = rst[1]
                minimum_value = n
                print(f"{minimum_value} -> {longest_length}")
    # 14316


def get_amicable_chain_len(num):
    check = True
    chain = [num]
    while True:
        next_num = sum_proper_divisors(chain[-1])
        if next_num > 1_000_000 or next_num == 0 or next_num in chain[1:]:
            check = False
            break
        if next_num == num:
            break
        chain.append(next_num)
    return (check, len(chain))


def sum_proper_divisors(num):
    rst = set()
    for n in range(1, int(num ** 0.5) + 1):
        if num % n == 0:
            rst.add(n)
            rst.add(num // n)
    return sum(rst) - num

if __name__ == "__main__":
    PE095()

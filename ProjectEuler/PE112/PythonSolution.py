
def is_bouncy(num: int):
    prevnum = int(str(num)[0])
    inc = False
    dec = False
    for c in str(num):
        if int(c) > prevnum:
            inc = True
        if int(c) < prevnum:
            dec = True
        prevnum = int(c)
    return (inc and dec) is True


def main():
    criteria = 99
    total = 0
    curnum = 1
    while True:
        if is_bouncy(curnum):
            total += 1
        percent = int(total / curnum * 100)
        if percent >= criteria:
            print(curnum)  # 1587000
            return
        curnum += 1


if __name__ == "__main__":
    main()

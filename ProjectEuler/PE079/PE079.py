def main():
    filename = ".\p079_keylog.txt"
    with open(filename, 'r') as f:
        lines = f.read().strip().split('\n')

    passcode = lines[0]
    changed = True
    while changed == True:
        changed = False
        for line in lines:
            for idx in range(0, len(passcode) - 1):
                if passcode[idx:idx+2] == line[0]+line[-1]:
                    changed = True
                    passcode = passcode[:idx] + line + passcode[idx+2:]
                elif passcode[:2] == line[1:]:
                    changed = True
                    passcode = line[0] + passcode
                elif passcode[-2:] == line[:2]:
                    changed = True
                    passcode = passcode + line[-1]
    print(passcode)  # 73162890


if __name__ == "__main__":
    main()

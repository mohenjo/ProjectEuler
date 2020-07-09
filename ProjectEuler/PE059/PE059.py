# -*- coding: utf-8 -*-


def main():
    with open("p059_cipher.txt", 'r') as f:
        encrypt = f.read()
    encrypt = tuple(map(int, encrypt.split(',')))
    # 소문자 ascii: [97,122]
    keys = [(p, m, s) for p in range(97, 123) for m in range(97, 123) for s in range(97, 123)]
    max_spaces, decrypt_key, decrypt_msg = 0, None, None
    for key in keys:
        tmp_decrypt = tuple(e ^ key[idx % 3] for idx, e in enumerate(encrypt))
        foo = tmp_decrypt.count(32)
        if foo > max_spaces:
            max_spaces = foo
            decrypt_key = key
            decrypt_msg = tmp_decrypt[:]

    # 공백이 제일 많이 검출되는 (영어 문장이라 판단되는) 키에 대한 메세지의 아스키 값 제너레이터
    # decrypt = tuple(e ^ decrypt_key[idx % 3] for idx, e in enumerate(encrypt))
    print("encryption key:", "".join(chr(c) for c in decrypt_key))
    print("decrypted message:", "".join(chr(c) for c in decrypt_msg))
    print("sum of ascii values in decrypted message: ", sum(decrypt_msg))  # 129448


if __name__ == "__main__":
    main()

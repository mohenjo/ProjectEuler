import re

def main():
    max_d = 0
    max_len = 0
    for i in range(2, 1000):
        print("{} of {} processing..".format(i, 1000), end="\r")
        dec = Fraction2Decimal(1, i, 3000) # 소수점 이하 3000자리 계산
        rec = reccuringString(dec)
        chk = len(rec)
        if chk > max_len:
            max_len = chk
            max_d = i
    print()
    print(max_d)
    

def reccuringString(string):
    p = re.compile(r"(\d+?)\1+$") 
    chk = p.search(string)
    if chk:
        rst = chk.group(1)
    else:
        rst = ""
    return rst
    
    
def Fraction2Decimal(numerator, denominator, span):
    """(n)umerator/(d)enominator를 계산하여 소수점 이하 span 자리까지 문자열 반환"""
    n = numerator
    d = denominator
    string = str(n // d) + "."
    remainer = n % d
    for i in range(span):
        if remainer == 0:
            break
        remainer = remainer * 10
        string = string + str(remainer // d)
        remainer = remainer % d
    return string

    
if __name__=="__main__":
    main()
    
# 983
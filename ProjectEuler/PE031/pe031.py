"""
pence(p): 1, 2, 5, 10, 20, 50
pound(L): 1 (= 100p), 2

L200 = a*p1 + b*p2 + c*p5 + d*p10 + e*p20 + f*p50 + g*L1 + h*L2
where,
0<= 계수(a, b, ..., h) <= 200/item_value
"""

## initialize
t = 200 # target value
pool = [1, 2, 5, 10, 20, 50, 100, 200]


def cal():
    cases = 0
    for a in range(0, t+1):
        print("{0:6.2f}% processing.".format(a/t*100), end="\r")
        for b in range(0, int(t/2)+1):
            if a + b*2 > t: break
            for c in range(0, int(t/5)+1):
                if a + b*2 + c*5 > t: break
                for d in range(0, int(t/10)+1):
                    if a + b*2 + c*5 + d*10 > t: break
                    for e in range(0, int(t/20)+1):
                        if a + b*2 + c*5 + d*10 + e*20 > t: break
                        for f in range(0, int(t/50)+1):
                            if a + b*2 + c*5 + d*10 + e*20 + f*50 > t: break
                            for g in range(0, int(t/100)+1):
                                if a + b*2 + c*5 + d*10 + e*20 + f*50 + g*100 > t:break
                                for h in range(0, int(t/200)+1):
                                    rst = a + b*2 + c*5 + d*10 + e*20 + f*50 + g*100 + h*200
                                    if rst > t: break
                                    if rst == t:
                                        cases += 1
    return cases

    
def main():
    rst = cal()
    print()
    print(rst)
    
    
    
if __name__=="__main__":
    main()
    
# 73682

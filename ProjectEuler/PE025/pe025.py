def GenFibo():
    """피보나치 수열 생성"""
    a = 1
    b = 1
    while True:
        yield a
        c = a + b
        a = b
        b = c
    
    
def main():
    fibo = GenFibo()
    idx = 0
    generated = ""
    while len(generated) < 1000:
        generated = str(next(fibo))
        idx += 1
    print(idx)
    
    
if __name__=="__main__":
    main()
    
# 4782
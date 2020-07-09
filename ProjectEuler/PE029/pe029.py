def main():
    pool = set()
    for a in range(2, 100+1):
        for b in range(2, 100+1):
            pool.add(a**b)
    rst = list(pool)
    rst.sort()
    print(len(rst))
    
    
if __name__=="__main__":
    main()
    
# 9183
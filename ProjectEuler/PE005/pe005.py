def main():
    chk_lst = range(1, 21)
    skip = max(chk_lst)
    current = skip
    
    while not chk_divisible(current, chk_lst):
        current += skip
        
    print(current)

    
def chk_divisible(n, lst):
    chk = all(map(lambda x: n % x == 0, lst))
    return chk

    
if __name__=="__main__":
    main()
    
# Answer: 232792560
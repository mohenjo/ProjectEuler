import itertools

def main():
    string = "0123456789"
    perm = tuple(itertools.permutations(string, len(string)))
    rst = "".join(perm[1000000-1])
    print(rst)
    
    
if __name__=="__main__":
    main()

# 2783915460
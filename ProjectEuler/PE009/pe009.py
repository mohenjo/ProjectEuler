def main():
    for a in range(1,int(1000/3)+1):
        for b in range(a+1, int(500-a/2)+1): # b < c <=> b < 1000-(a+b) <=> b < 500 - a/2
            if chkVal(a, b):
                print(a * b * (1000-(a+b)))


def chkVal(a, b):
    left_term = a**2 + b**2
    right_term = (1000 - (a + b))**2
    return left_term == right_term

    
if __name__=="__main__":
    main()

# Answer: 31875000
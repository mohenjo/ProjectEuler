
def sumOfSquares(lst):
    return sum([x**2 for x in lst])


def squareOfSum(lst):
    return sum(lst)**2
    
    
def main():
    scope = range(1, 101)
    print(abs(sumOfSquares(scope) - squareOfSum(scope)))

    
if __name__=="__main__":
    main()
    
# Answer: 25164150
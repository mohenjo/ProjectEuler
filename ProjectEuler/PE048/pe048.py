def last10digits(n):
    """n**n의 마지막 10자리 숫자를 반환"""
    string = str(n**n)
    last10 = int(string[-10:]) 
    return last10

    
def main():
    summation = 0
    for i in range(1, 1001):
        summation += last10digits(i)
    print(str(summation)[-10:])
    
    
if __name__=="__main__":
    main()

# 9110846700    
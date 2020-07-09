"""solution
A by A spiral (clockwise)에 대해 다음과 같은 관계가 성립한다.

매트릭스의 크기:
(2N+1) by (2N+1) matrix는 N개의 레이어로 구성된다. 단 N int >=0

v0 = 중간점(출발값) = 1

n-th 레이어에 대해, 단 0 <= n <= N

우하단 값 eqRD(n) = eqRD(n-1) + (2 + 8*(n-1)) where n >= 1, eqRD(0) = v0 = 1
좌하단 값 eqLD(n) = eqRD(n) + 2*n
좌상단 값 eqLU(n) = eqLD(n) + 2*n
우상단 값 eqRU(n) = eqLU(n) + 2*n
where eqLD(0) = eqLU(0) = eqRU(0) = 0
"""

def getNumLayer(A): # A by A 매트릭스의 크기로 부터 레이어의 개수 반환
    return int((A-1)/2)


def eqRD(n): # 우하단 값
    v0 = 1 # spiral matrix 출발 값
    rst = v0 if n==0 else eqRD(n-1) + (2 + 8*(n-1)) 
    return rst
    

def eqLD(n): # 좌하단 값
    rst = eqRD(n) + 2*n if n>0 else 0
    return rst
    
    
def eqLU(n): # 좌상단 값
    rst = eqLD(n) + 2*n if n>0 else 0
    return rst
    

def eqRU(n): # 우상단 값
    rst = eqLU(n) + 2*n if n>0 else 0
    return rst

    
def layerSum(n): 
    ## n-th (n int >=0) 레이어까지의 각 대각지점 값의 합 반환
    ## sum of numbers on the spiral diagonals 
    rst = 0
    for i in range(n+1):
        rst += (eqRD(i)+eqLD(i)+eqLU(i)+eqRU(i))
    return rst
    
    
def main():
    numLayers = getNumLayer(1001) # 1001 by 1001 matrix
    rst = layerSum(numLayers)
    print(rst)
    

if __name__=="__main__":
    main()

# 669171001

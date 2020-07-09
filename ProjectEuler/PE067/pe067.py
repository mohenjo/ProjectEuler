# initialize
with open("./pe067_triangle.txt", "r") as f:
    raw_input = f.read()

raw_input = raw_input.splitlines()
lst = list()
for strings in raw_input:
    lst.append([int(string) for string in strings.split(" ")])

    
def shortenByMax(input_lst): # len(input_lst) >= 2
    ## 입력 리스트의 인접 두 수를 비교, 큰 수를 선택하여 len-1의 리스트 반환
    rst = list()
    for i in range(len(input_lst)-1):
        maxVal = input_lst[i] if input_lst[i] > input_lst[i+1] else input_lst[i+1]
        rst.append(maxVal)
    return rst

def addLists(listA, listB): # 두 리스트는 같은 길이
    rst = [listA[i] + listB[i] for i in range(len(listA))]
    return rst
        

def shortenRecur(input_lst): # input_lst = list of lists
    if len(input_lst) == 1:
        return input_lst # 리스트의 길이가 1이 되면 반환
    else: # 그 전에는
        popped = input_lst.pop() # 리스트 마지막 요소(리스트)를 뽑아서
        # shortenByMax 한 값을 남은 리스트의 마지막 요소(리스트)에 더하고
        input_lst[-1] = addLists(input_lst[-1], shortenByMax(popped))
        return shortenRecur(input_lst) # 이를 재귀 반복

        
def main():
    rst = shortenRecur(lst)
    print(rst)
    
    
if __name__=="__main__":
    main()

    
# 7273
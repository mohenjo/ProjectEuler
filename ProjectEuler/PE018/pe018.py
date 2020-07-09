# initialize
raw_input="""75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23"""
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

    
# 1074
## initialize
n2wMap = [None for i in range(1001)]
dic0to9 = ("zero", "one","two", "three", "four", "five", "six", "seven", "eight", "nine")
dic11to19 = ("eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen")
dic10s = ("ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" )
## [0, 99]
for i in range(100):
    if i <= 9: # [0, 9)
        n2wMap[i] = dic0to9[i]
    elif 11 <= i <= 19: # [11, 19]
        n2wMap[i] = dic11to19[i-11]
    elif i % 10 == 0: # 10, 20, 30...
        n2wMap[i] = dic10s[i//10-1]
    else:
        # n2wMap[i] = dic10s[i//10-1] + "-" + dic0to9[i%10]
        n2wMap[i] = dic10s[i//10-1] + dic0to9[i%10]
## [100, 999]
for i in range(100, 1000):
    if i % 100 == 0:
        # n2wMap[i] = dic0to9[i//100] + " hundred"
        n2wMap[i] = dic0to9[i//100] + "hundred"
    else:
        # n2wMap[i] = dic0to9[i//100] + " hundred and " + n2wMap[i%100]
        n2wMap[i] = dic0to9[i//100] + "hundredand" + n2wMap[i%100]
## 1000
n2wMap[1000] = "onethousand"
        
def main():
    accu = sum([len(s) for s in n2wMap[1:]]) # exclude 0 [zero]
    print(accu)
    
if __name__=="__main__":
    main()
    
# 21124

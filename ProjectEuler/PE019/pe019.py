import datetime

def main():
    years = range(1901, 2001)
    months = range(1, 13)
    count = 0
    for year in years:
        for month in months:
            chk = datetime.date(year, month, 1).weekday()
            if chk == 6: # 0: Mon ... 6: Sun
                count +=1
            
    print(count)
    
if __name__=="__main__":
    main()
    
# 171
    
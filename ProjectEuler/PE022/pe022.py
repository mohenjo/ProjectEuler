## initialize
with open("./pe022_names.txt","r") as f:
    raw_input = f.read()
raw_input = sorted(raw_input.replace('"', '').split(","))
base = ord("A")

def main():
    name_scores = 0
    for i, string in enumerate(raw_input):
        name_scores += (i+1) * sum([ord(s)-(base-1) for s in string])
    print(name_scores)
    
if __name__=="__main__":
    main()
        
# 871198282